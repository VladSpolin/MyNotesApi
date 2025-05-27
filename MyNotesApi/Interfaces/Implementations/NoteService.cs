using Microsoft.EntityFrameworkCore;
using MyNotesApi.Contracts;
using MyNotesApi.DataAccess;
using MyNotesApi.Models;
using MyNotesApi.Models.Dtos;
using System.Linq.Expressions;

namespace MyNotesApi.Interfaces.Implementations
{
    public class NoteService : INoteService
    {
        private readonly NotesDbContext _context;
        public NoteService(NotesDbContext context)
        {
            _context = context;
        }
        public async Task Create(CreateNoteRequest request, CancellationToken ct)
        {
            var note = new Note(request.Title, request.Description);
             await _context.Notes.AddAsync(note, ct);
            await _context.SaveChangesAsync(ct);

        }

        public async Task<GetNotesResponse> Get(GetNotesRequest request, CancellationToken ct)
        {
            var notesQuery = _context.Notes
                .Where(n=>string.IsNullOrWhiteSpace(request.Search) || 
                n.Title.ToLower().Contains(request.Search.ToLower()));

            var selectorKey = GetSeletorKey(request.SortItem);

            notesQuery = request.SortOrder == "desc"
                ? notesQuery.OrderByDescending(selectorKey)
                : notesQuery.OrderBy(selectorKey);

            var noteDtos = await notesQuery.Select(n => new NoteDto(n.Id,n.Title,n.Description,n.CreatedAt))
                .ToListAsync(cancellationToken: ct);
            return new GetNotesResponse(noteDtos);
        }

        private Expression<Func<Note, object>> GetSeletorKey(string? sortItem)
        { 
            return sortItem?.ToLower() switch
            {
                "date" => note => note.CreatedAt,
                "title" => note=>note.Title,
                _=> note => note.Id
            };

        }
    }
}
