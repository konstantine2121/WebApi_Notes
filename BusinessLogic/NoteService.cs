using DataAccess;

namespace BusinessLogic;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
    {
        var note = new Note()
        { 
            Text = text
        };

        await _noteRepository.CreateAsync(note, cancellationToken);
    }

    public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note == null)
        {
            throw new KeyNotFoundException("Note not found");
        }
        
        return note.Text;
    }

    public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note == null)
        {
            throw new KeyNotFoundException("Note not found");
        }
        
        note.Text = newText;
        await _noteRepository.UpdateAsync(note, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note == null)
        {
            throw new KeyNotFoundException("Note not found");
        }
        
        await _noteRepository.DeleteAsync(note, cancellationToken);
    }
}