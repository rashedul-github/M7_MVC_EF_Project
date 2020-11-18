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
    public class ClientsController : Controller
    {
        // GET: Clients
        IClientRepo clientRepo = new ClientRepo();
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Client> lstClient = this.clientRepo.GetAll();
            return View(lstClient);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Client c)
        {
            if (ModelState.IsValid)
            {
                this.clientRepo.Insert(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Edit(int id)
        {
            var data = this.clientRepo.GetClientId(id);
            return View(data);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Client c)
        {
            if (ModelState.IsValid)
            {
                this.clientRepo.Update(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Delete(int id)
        {
            var data = this.clientRepo.GetClientId(id);
            return View(data);
        }
        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                this.clientRepo.Delete(id);
                return RedirectToAction("Index");
            }
            return View(id);
        }

    }
}