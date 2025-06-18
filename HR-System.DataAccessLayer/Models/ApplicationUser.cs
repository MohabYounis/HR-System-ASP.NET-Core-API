using Microsoft.AspNetCore.Identity;

namespace HR_System.DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
