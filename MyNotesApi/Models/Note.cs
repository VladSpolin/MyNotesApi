﻿namespace MyNotesApi.Models
{
    public class Note
    {
        public Note(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public string Title { get; init; } 
        public string Description { get; init; } 
        public DateTime CreatedAt { get; init; } 

    }
}
