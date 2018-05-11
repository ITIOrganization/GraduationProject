using AlumniSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WorkingCode.CodeProject.PwdGen;

namespace AlumniSystem.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        //Get All Graduates
        [HttpGet]
        public ActionResult Graduates()
        {
            return View(db.Graduates.Where(n => n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Graduate).Id)).ToList<Graduate>());
        }
        //Get All Staff
        [HttpGet]
        public ActionResult Staff()
        {
            return View(db.Staff.Where(n => n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Staff).Id)).ToList<Staff>());
        }
        //Get All Companies
        [HttpGet]
        public ActionResult Companies()
        {
            return View(db.Companies.Where(n => n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Company).Id)).ToList<Company>());
        }

        //Get All Blocked Graduates
        [HttpGet]
        public ActionResult BlockedGraduates()
        {
            return View(db.Graduates.Where(n => !n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Graduate).Id)).ToList<Graduate>());
        }
        //Get All Blocked Staff
        [HttpGet]
        public ActionResult BlockedStaff()
        {
            return View(db.Staff.Where(n => !n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Staff).Id)).ToList<Staff>());
        }
        //Get All Blocked Companies
        [HttpGet]
        public ActionResult BlockedCompanies()
        {
            return View(db.Companies.Where(n => !n.ApplicationUser.Roles.Select(x => x.RoleId).Contains(db.Roles.FirstOrDefault(c => c.Name == _Roles.Company).Id)).ToList<Company>());
        }

        public async Task<ActionResult> BlockGraduate(string Id)
        {
            await userManager.RemoveFromRolesAsync(Id, _Roles.Graduate);
            return RedirectToAction("Graduates");
        }
        public async Task<ActionResult> ApproveGraduate(string Id)
        {
            await userManager.AddToRolesAsync(Id, _Roles.Graduate);
            return RedirectToAction("BlockedGraduates");
        }
        public async Task<ActionResult> BlockStaff(string Id)
        {
            await userManager.RemoveFromRolesAsync(Id, _Roles.Staff);
            return RedirectToAction("Staff");
        }
        public async Task<ActionResult> ApproveStaff(string Id)
        {
            await userManager.AddToRolesAsync(Id, _Roles.Staff);
            return RedirectToAction("BlockedStaff");
        }
        public async Task<ActionResult> BlockCompany(string Id)
        {
            await userManager.RemoveFromRolesAsync(Id, _Roles.Company);
            return RedirectToAction("Companies");
        }
        public async Task<ActionResult> ApproveCompany(string Id)
        {
            //isConfirmed??
            await userManager.AddToRolesAsync(Id, _Roles.Company);
            return RedirectToAction("BlockedCompanies");
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
                    Fname = model.Fname,
                    Lname = model.Lname,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address,
                    ProfileImage = model.ProfileImage,
                    DateOfBirth=DateTime.Now.AddYears(-25)
                };

                //Generate Random Password
                PasswordGenerator passwordGenerator = new PasswordGenerator();
                passwordGenerator.Maximum = 10;
                passwordGenerator.ConsecutiveCharacters = true;
                passwordGenerator.RepeatCharacters = true;
                passwordGenerator.ExcludeSymbols = true;
                var password = passwordGenerator.Generate();

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var graduate = new Graduate
                    {
                        Id = user.Id,
                        Intake=model.Intake,
                        TrackId = model.TrackId,
                        BranchId = model.BranchId
                    };
                    try
                    {
                        db.Graduates.Add(graduate);
                        db.SaveChanges();

                        await userManager.AddToRoleAsync(user.Id, _Roles.Graduate);
                        ////////////send email to graduate include userName and Password

                        return RedirectToAction("index");
                    }
                    catch
                    {
                        return View(model);
                    }
                }
            }

            var tracks = new SelectList(db.Tracks.ToList(), "Id", "Name");
            var branchs = new SelectList(db.Branches.ToList(), "Id", "Name");
            ViewBag.tracks = tracks;
            ViewBag.branchs = branchs;
            return View(model);
        }

        public JsonResult CheckEmail(string email)
        {
            return Json(_RemoteCheck.CheckNameRemote(email, null, (em) => userManager.Users.Any(c => c.Email == em)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUserName(string UserName)
        {
            return Json(_RemoteCheck.CheckNameRemote(UserName, null, (n) => userManager.Users.Any(c => c.UserName == n)), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckPhone(string companyPhone, string PhoneNumber)
        {
            if (companyPhone != null)
                return Json(_RemoteCheck.CheckPhoneRemote(companyPhone, null, (ph) => db.Companies.Any(c => c.CompanyPhone == ph)), JsonRequestBehavior.AllowGet);
            if (PhoneNumber != null)
                return Json(_RemoteCheck.CheckPhoneRemote(PhoneNumber, null, (ph) => userManager.Users.Any(c => c.PhoneNumber == ph)), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Action", "Account");
        }



    }

}
    
