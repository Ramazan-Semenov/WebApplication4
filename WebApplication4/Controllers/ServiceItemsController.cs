using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ServiceItemsController : Controller
    {


        private readonly MyCompanyContext articlesRepository;

        public ServiceItemsController(MyCompanyContext articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var model = articlesRepository.ServiceItems.ToList();
            return View(model);
        }

        // GET: ServiceItems/Details/5
        public ActionResult Details(int id)
        {
            ServiceItems model = articlesRepository.ServiceItems.Where(x => x.Id == id).FirstOrDefault<ServiceItems>();
            return View(model);
        }

       // GET: ServiceItems/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ServiceItems/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ServiceItems items)
        {
            Trace.WriteLine("-----------------------------");
           
                //if (ModelState.IsValid)
                //{
                    articlesRepository.ServiceItems.Add(items);
                    articlesRepository.SaveChanges();
                    return RedirectToAction("Index");
            //    }

            //return RedirectToAction("Index");

        }

        // GET: ServiceItems/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceItems model = articlesRepository.ServiceItems.Where(x => x.Id == id).FirstOrDefault<ServiceItems>();

            return View(model);
        }

        // POST: ServiceItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceItems items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articlesRepository.ServiceItems.Update(items);
                    articlesRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceItems/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: ServiceItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ServiceItems id)
        {
            try
            {
                if (id != null)
                {

                    articlesRepository.Remove(id);

                    articlesRepository.SaveChanges();
                        return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
