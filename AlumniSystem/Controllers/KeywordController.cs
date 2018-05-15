using AlumniSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlumniSystem.Controllers
{
    public class KeywordController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Keyword
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllKeywords());
        }
        IEnumerable<Keyword> GetAllKeywords()
        {
            return db.Keywords.ToList<Keyword>();
        }
        public ActionResult Addoredit(int id = 0)
        {
            Keyword key = new Keyword();
            if (id != 0)
            {
                key = db.Keywords.Where(em => em.Id == id).FirstOrDefault<Keyword>();
            }
            return View(key);
        }
        [HttpPost]
        public ActionResult Addoredit(Keyword key,string name)
        {
            if (db.Keywords.Any(t => t.Name == name))
                return Content("exist");
            else if (key.Id == 0)
            {
                db.Keywords.Add(key);
                db.SaveChanges();
            }
            else
            {
                db.Entry(key).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { success = true, message = "keyword Added successfully" }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("ViewAll");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Keyword key = db.Keywords.Where(t => t.Id == id).FirstOrDefault<Keyword>();
                db.Keywords.Remove(key);
                db.SaveChanges();
                return Json(new { success = true, message = "keyword Deleted successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}