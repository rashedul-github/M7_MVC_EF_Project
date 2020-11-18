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
    public class ContentsController : Controller
    {
        // GET: Contents
        IContentRepo contentRepo = new ContentRepo();
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Content> lstContent = this.contentRepo.GetAll();
            return View(lstContent);
        }
        public ActionResult Create()
        {
            ViewBag.Client = this.contentRepo.GetClient();
            ViewBag.Project = this.contentRepo.GetProject();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public PartialViewResult Create(Content c)
        {
            ViewBag.Client = this.contentRepo.GetClient();
            ViewBag.Project = this.contentRepo.GetProject();
            if (ModelState.IsValid)
            {
                this.contentRepo.Insert(c);
                return PartialView("_success");
            }
            else
            {
                return PartialView("_fail");
            }
        }
        public ActionResult Edit(int id)
        {
            var data = this.contentRepo.GetContentId(id);
            ViewBag.Client = this.contentRepo.GetClient();
            ViewBag.Project = this.contentRepo.GetProject();
            return View(data);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Content c)
        {
            if (ModelState.IsValid)
            {
                this.contentRepo.Update(c);
                return RedirectToAction("Index");
            }
            ViewBag.Client = this.contentRepo.GetClient();
            ViewBag.Project = this.contentRepo.GetProject();
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            var data = this.contentRepo.GetContentId(id);
            return View(data);
        }
        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                this.contentRepo.Delete(id);
                return RedirectToAction("Index");
            }
            return View(id);
        }


    }
}