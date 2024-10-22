using CrudInCoreDBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudInCoreDBFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CodefirstdbContext context;

        public HomeController(ILogger<HomeController> logger , CodefirstdbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var data =context.Students.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public  IActionResult Create( Student std)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(std);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View(std);
        }


        public IActionResult Edit( int? id)
        {
            var stdata = context.Students.Find(id);
            return View(stdata);
        }
        [HttpPost]
        public IActionResult Edit(int? id,Student std)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(std);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
           
            return View(std);
        }

        public IActionResult Delete(int? id)
        {
            var stdata = context.Students.Find(id);
            return View(stdata);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var stdata = context.Students.Find(id);

            if (stdata != null)
            {
                context.Students.Remove(stdata);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

               
          

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
