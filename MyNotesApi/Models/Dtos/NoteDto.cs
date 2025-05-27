using System.Globalization;

namespace MyNotesApi.Models.Dtos
{
    public record NoteDto(Guid Id, string Title, string Description, DateTime CreatedAt);   
}
