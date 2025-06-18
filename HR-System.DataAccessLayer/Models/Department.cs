using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.DataAccessLayer.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        [Required]

        public string Name { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [ForeignKey(nameof(Manager))]
        public int? ManagerSSN { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
