namespace DataAccess;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    
    Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<Note>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    
}