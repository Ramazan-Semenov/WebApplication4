using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplication1.Data.ApplicationDbContext My;
        public HomeController(WebApplication1.Data.ApplicationDbContext context)
        {
            My = context;
        }


        public IActionResult Index()
        {

            //  Trace.WriteLine( My.ServiceItems.FirstOrDefault().Id+"=================================");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    
    }
}
