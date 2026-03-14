namespace TaskBoard.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        // Task title
        public string Name { get; set; }

        // Task description
        public string Description { get; set; }

        // Deadline of the task
        public DateTime Deadline { get; set; }

        // Favorite tasks should appear first
        public bool IsFavorite { get; set; }

        // Optional image attachment
        public string? ImageUrl { get; set; }

        // Foreign key for column
        public int ColumnId { get; set; }

        // Navigation property
        public BoardColumn? Column { get; set; }
    }
}