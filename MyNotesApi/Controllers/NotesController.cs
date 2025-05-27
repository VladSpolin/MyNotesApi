using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyNotesApi.Contracts;
using MyNotesApi.Interfaces;

namespace MyNotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService )
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateNoteRequest request, CancellationToken ct)
        {
            await _noteService.Create(request, ct);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetNotesRequest request, CancellationToken ct)
        {

            return Ok(await _noteService.Get(request, ct));
        }
    }
}
