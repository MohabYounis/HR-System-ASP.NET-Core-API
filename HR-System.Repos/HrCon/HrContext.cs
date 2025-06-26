using HR_System.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Repos.HrCon
{
    public class HrContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
                                IdentityUserClaim<string>, ApplicationUserRole,
                                IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<AttendanceAndLeave> AttendanceAndLeaves { get; set; }
        public virtual DbSet<AnnualHolidays> AnnualHolidays { get; set; }
        public virtual DbSet<GeneralSetting> GeneralSettings { get; set; }
        public virtual DbSet<WeeklyHolidays> WeeklyHolidays { get; set; }


        public HrContext() : base() { }
        public HrContext(DbContextOptions<HrContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(ur =>
            {
                // Composite Primary Key
                ur.HasKey(k => new { k.UserId, k.RoleId });

                // User <---> UserRoles
                ur.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                // Role <---> UserRoles
                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            // Employee <---> AssignedDepartment
            builder.Entity<Employee>()
                .HasOne(e => e.AssignedDepartment)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Dept_Num)
                .OnDelete(DeleteBehavior.NoAction);

            // ManagedDepartment <---> Manager(Employee)
            builder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(e => e.ManagedDepartment)
                .HasForeignKey<Department>(d => d.ManagerSSN)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
