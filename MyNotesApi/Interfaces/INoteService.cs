using MyNotesApi.Contracts;
using MyNotesApi.Models.Dtos;

namespace MyNotesApi.Interfaces
{
    public interface INoteService
    {
        Task Create(CreateNoteRequest request, CancellationToken ct);
        Task<GetNotesResponse> Get(GetNotesRequest request, CancellationToken ct);
    }
}
