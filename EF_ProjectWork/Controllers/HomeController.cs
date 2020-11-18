using Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace EF_ProjectWork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        IHomeRepo homeRepo = new  HomeRepo();
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            int perPage = 2;
            var data = this.homeRepo.GetOrder()
                .ToPagedList(page, perPage);
            ViewBag.TotalPages = this.homeRepo.pageCount(2);
            ViewBag.CurrentPage = page;
            return View(data);
        }
        [AllowAnonymous]
        public PartialViewResult GetContent(int id)
        {
            var data = this.homeRepo.GetRelated(id);
 
            ViewBag.ProjectName = this.homeRepo.ProjectName(id);

            return PartialView("_GetContent",data);
        }

        public ActionResult Add()
        {
            tables t = new tables();
            return View(t);
        }
        [HttpPost]
        public ActionResult Add(tables t)
        {
            if (ModelState.IsValid)
            {
                this.homeRepo.Add(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }
    }
}