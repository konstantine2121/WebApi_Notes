using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Notes.Controllers;

[ApiController]
[Route("Note")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(string text)
    {
        await _noteService.CreateAsync(text);
        return NoContent();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetNoteAsync([FromRoute]int id)
    {
        var result = await _noteService.GetByIdAsync(id);
        return Ok(result);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateNoteAsync([FromRoute]int id, string newText)
    {
        await _noteService.UpdateAsync(id, newText);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteNoteAsync([FromRoute]int id)
    {
        await _noteService.DeleteAsync(id);
        return NoContent();
    }
}