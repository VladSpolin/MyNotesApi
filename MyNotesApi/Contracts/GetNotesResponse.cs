using MyNotesApi.Models.Dtos;

namespace MyNotesApi.Contracts
{
    public record GetNotesResponse(List<NoteDto> Nodes);
}
