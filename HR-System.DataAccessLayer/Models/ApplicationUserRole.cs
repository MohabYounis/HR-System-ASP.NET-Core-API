using Microsoft.AspNetCore.Identity;

namespace HR_System.DataAccessLayer.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
