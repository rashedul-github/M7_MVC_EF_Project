using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_ProjectWork.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        // GET: Projects
        IProjectRepo projectRepo = new ProjectRepo();
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Project> lstProject = this.projectRepo.GetAll();
            return View(lstProject);
        }
        public ActionResult Create()
        {
            ViewBag.Client = this.projectRepo.GetClient();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Project p)
        {
            if (ModelState.IsValid)
            {
                this.projectRepo.Insert(p);
                return RedirectToAction("Index");
            }
            ViewBag.Client = this.projectRepo.GetClient();
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Client = this.projectRepo.GetClient();
            var data = this.projectRepo.GetProjectId(id);
            return View(data);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Project p)
        {
            if (ModelState.IsValid)
            {
                this.projectRepo.Update(p);
                return RedirectToAction("Index");
            }
            ViewBag.Client = this.projectRepo.GetClient();
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            var data = this.projectRepo.GetProjectId(id);
            return View(data);
        }
        [HttpPost, ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                this.projectRepo.Delete(id);
                return RedirectToAction("Index");
            }
            return View(id);
        }

    }
}