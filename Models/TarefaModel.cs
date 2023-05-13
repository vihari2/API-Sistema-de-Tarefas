using WorkSystem.Enums;

namespace WorkSystem.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }
    }
}
