using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class NoteRepository : INoteRepository
{
    private readonly AppContext _context;

    public NoteRepository(AppContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Created = DateTime.UtcNow;
        await _context.Notes.AddAsync(note, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Notes.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Note>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        HashSet<Guid> idsSet = new HashSet<Guid>(ids);
        
        return await _context.Notes.Where(note => idsSet.Contains(note.Id)).ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Updated = DateTime.UtcNow;
        _context.Notes.Update(note);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync(cancellationToken);
    }
}