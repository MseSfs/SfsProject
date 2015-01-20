using AspnetIdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AspnetIdentitySample
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // You want to create a new database each time when the application starts
    // public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    public class SfsDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(MyDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // create role and user 'Test' ------------------------------------
            string nameTest = "Test";
            RoleManager.Create(new IdentityRole(nameTest));
            UserManager.Create(new ApplicationUser() { UserName = nameTest });

            // create role and user for admin ---------------------------------
            var userInfoAdmin = new MyUserInfo() { FirstName = "Pranav", LastName = "Rastogi" };
            string nameAdmin = "Admin";
            string passwordAdmin = "123456";
            // create role 'Admin* if it doesn't exist
            if (!RoleManager.RoleExists(nameAdmin))
            {
                var roleresult = RoleManager.Create(new IdentityRole(nameAdmin));
            }

            // create user=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = nameAdmin;
            user.HomeTown = "Seattle";
            user.MyUserInfo = userInfoAdmin;
            var adminresult = UserManager.Create(user, passwordAdmin);
            // add user Admin to role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, nameAdmin);
            }

            // create role 'Common' and users for this role  ------------------
            string nameCommon = "Common";
            RoleManager.Create(new IdentityRole(nameCommon));
            // create and add users
            var commonUser1 = new ApplicationUser()
            {
                UserName = "swinkler",
                HomeTown = "Königswiesen",
                MyUserInfo = new MyUserInfo() { FirstName = "Sabine", LastName = "Winkler" }
            };
            var commonUserResult = UserManager.Create(commonUser1, "test123");
            if (commonUserResult.Succeeded)
            {
                UserManager.AddToRole(commonUser1.Id, nameCommon);
            }
            var commonUser2 = new ApplicationUser()
            {
                UserName = "tluger",
                HomeTown = "Neustift",
                MyUserInfo = new MyUserInfo() { FirstName = "Thomas", LastName = "Luger" }
            };
            commonUserResult = UserManager.Create(commonUser2, "test123");
            if (commonUserResult.Succeeded)
            {
                UserManager.AddToRole(commonUser2.Id, nameCommon);
            }

            // create and add projects ----------------------------------------
            MyDbContext db = new MyDbContext();
            var project = new Project()
            {
                Name = "HMI for data visualization",
                Description = "Development of a a simle and intuitive human machine interface for data visualization"
            };
            db.Projects.Add(project);
            project = new Project()
            {
                Name = "Threat modeling for existing software",
                Description = "For already existing software systems in the company a threat model " +
                    "should be created and analysed if it wasen't done yet."
            };
            db.Projects.Add(project);
            project = new Project()
            {
                Name = "Improvement of development process",
                Description = "New processes and methods for software development process should be evaluated"
            };
            db.Projects.Add(project);
            db.SaveChanges();
        }
    }
}