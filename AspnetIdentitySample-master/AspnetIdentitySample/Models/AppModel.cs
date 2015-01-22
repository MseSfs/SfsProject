using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AspnetIdentitySample.Models
{
    public class ApplicationUser : IdentityUser
    {
        // HomeTown will be stored in the same table as Users
        public string HomeTown { get; set; }
        
        // FirstName & LastName will be stored in a different table called MyUserInfo
        public virtual MyUserInfo MyUserInfo { get; set; }
    }

    public class MyUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SfsDbContext : IdentityDbContext<ApplicationUser>
    {
        public SfsDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<MyUserInfo> MyUserInfo { get; set; }

        public DbSet<Project> Projects { get; set; }
    }


}