using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AlumniSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlumniSystem.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> um = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

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
            await um.RemoveFromRolesAsync(Id, _Roles.Graduate);
            return RedirectToAction("Graduates");
        }
        public async Task<ActionResult> ApproveGraduate(string Id)
        {
            await um.AddToRolesAsync(Id, _Roles.Graduate);
            return RedirectToAction("BlockedGraduates");
        }
        public async Task<ActionResult> BlockStaff(string Id)
        {
            await um.RemoveFromRolesAsync(Id, _Roles.Staff);
            return RedirectToAction("Staff");
        }
        public async Task<ActionResult> ApproveStaff(string Id)
        {
            await um.AddToRolesAsync(Id, _Roles.Staff);
            return RedirectToAction("BlockedStaff");
        }
        public async Task<ActionResult> BlockCompany(string Id)
        {
            await um.RemoveFromRolesAsync(Id, _Roles.Company);
            return RedirectToAction("Companies");
        }
        public async Task<ActionResult> ApproveCompany(string Id)
        {
            await um.AddToRolesAsync(Id, _Roles.Company);
            return RedirectToAction("BlockedCompanies");
        }
    }
}