using AspnetIdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace AspnetIdentitySample.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Only Authenticated users can access their profile
        [Authorize]
        public new ActionResult Profile()
        {
            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SfsDbContext()));
            
            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId()); 
            
            // Recover the profile information about the logged in user
            ViewBag.HomeTown = currentUser.HomeTown;
            ViewBag.FirstName = currentUser.UserName;

            return View();
        }
    }
}