using System.ComponentModel.DataAnnotations;

namespace life_copilot_kernel.Models
{
    public class Action
    {
        [Key]
        public Guid Action_Id { get; set; }
        public string? Description { get; set; }
        public bool? isDone { get; set; }
    }
}
