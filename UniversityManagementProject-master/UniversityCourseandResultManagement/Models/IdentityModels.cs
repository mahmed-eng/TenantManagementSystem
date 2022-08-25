using Microsoft.AspNet.Identity.EntityFramework;

namespace UniversityCourseandResultManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<UniversityCourseandResultManagement.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<UniversityCourseandResultManagement.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<UniversityCourseandResultManagement.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<UniversityCourseandResultManagement.Models.Admin> Admins { get; set; }
    }
}