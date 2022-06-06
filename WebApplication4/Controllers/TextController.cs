using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TextController : Controller
    {
        private readonly MyCompanyContext articlesRepository;

        public TextController(MyCompanyContext articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        // GET: Text
        [Authorize(Roles = "admin")]

        public ActionResult Index()
        {
            var model = articlesRepository.TextFields.ToList();
            return View(model);
        }

        // GET: Text/Details/5
        public ActionResult Details(int id)
        {
            TextFields model = articlesRepository.TextFields.Where(x => x.Id == id).FirstOrDefault<TextFields>();
            return View(model);
        }

        // GET: Text/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Text/Create
        [HttpPost]
        public ActionResult Create(ServiceItems items)
        {
            articlesRepository.ServiceItems.Add(items);
            articlesRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Text/Edit/5
        public ActionResult Edit(int id)
        {

            TextFields model = articlesRepository.TextFields.Where(x => x.Id == id).FirstOrDefault<TextFields>();
            return View(model);
        }

        // POST: Text/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TextFields items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articlesRepository.TextFields.Update(items);
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

        // GET: Text/Delete/5
        public ActionResult Delete(int id)
        {

            TextFields model = articlesRepository.TextFields.Where(x => x.Id == id).FirstOrDefault<TextFields>();
            return View(model);
        }

        // POST: Text/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TextFields id)
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
