namespace TaskBoard.API.Models
{
    public class BoardColumn
    {
        public int Id { get; set; }

        // Column name (ToDo, In Progress, Done)
        public string Name { get; set; }

        // Tasks inside the column
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}