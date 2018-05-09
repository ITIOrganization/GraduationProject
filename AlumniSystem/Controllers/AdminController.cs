using AlumniSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AlumniSystem.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        //Add New Graduate

        [HttpGet]
        public ActionResult Add()
        {
            var tracks = new SelectList(db.Tracks.ToList(), "Id", "Name");
            var branchs = new SelectList(db.Branches.ToList(), "Id", "Name");
            ViewBag.tracks = tracks;
            ViewBag.branchs = branchs;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(GraduateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name=model.Name,
                    PhoneNumber=model.PhoneNumber,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address,
                    ProfileImage=model.ProfileImage,
                };


                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var graduate = new Graduate
                    {
                        Id=user.Id,
                        TrackId = model.Track.Id,
                        BranchId = model.Branch.Id
                    };
                    db.Graduates.Add(graduate);
                    db.SaveChanges();

                    await userManager.AddToRoleAsync(user.Id, _Roles.Graduate);

                    return RedirectToAction("index");
                }
            }
            return View(model);
        }


    }
}