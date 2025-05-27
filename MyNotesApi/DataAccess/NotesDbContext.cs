using Microsoft.EntityFrameworkCore;
using MyNotesApi.Models;

namespace MyNotesApi.DataAccess
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }
    }
}
