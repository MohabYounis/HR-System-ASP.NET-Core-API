using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        [Column(TypeName = "date")]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [ForeignKey(nameof(Manager))]
        public string ManagerSSN { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
