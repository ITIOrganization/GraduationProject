using AlumniSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlumniSystem.Controllers
{
    public class JobTitleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobTitle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAlljobTitles());
        }
        IEnumerable<JobTitle> GetAlljobTitles()
        {
             return db.JobTitles.ToList<JobTitle>();
          
        }
        public ActionResult Addoredit(int id = 0)
        {
            JobTitle jobb = new JobTitle();
            if (id != 0)
            {
                jobb = db.JobTitles.Where(em => em.Id == id).FirstOrDefault<JobTitle>();
            }
            return View(jobb);
        }
        [HttpPost]
        public ActionResult Addoredit(JobTitle jobb)
        {
             if (jobb.Id == 0)
            {
                db.JobTitles.Add(jobb);
                db.SaveChanges();
            }
            else
            {
                db.Entry(jobb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { success = true, message = "job title Added successfully" }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("ViewAll");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                JobTitle jobb = db.JobTitles.Where(t => t.Id == id).FirstOrDefault<JobTitle>();
                db.JobTitles.Remove(jobb);
                db.SaveChanges();
                return Json(new { success = true, message = "job title Deleted successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}