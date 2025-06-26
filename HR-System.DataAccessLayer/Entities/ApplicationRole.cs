using Microsoft.AspNetCore.Identity;

namespace HR_System.Core.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
