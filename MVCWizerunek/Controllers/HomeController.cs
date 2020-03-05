using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCWizerunek.Models;
using Microsoft.AspNetCore.Http.Extensions;


namespace MVCWizerunek.Controllers
{
    public class HomeController : Controller
    {
        public Licznik model = new Licznik() { counting = 0 };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
      
            return View();
        }

        public IActionResult Kontakt()
        {
            
            return View();
        }

        [HttpPost]
        [ActionName("kontakt")]
        public IActionResult Kontakt(string imiee)
        {
            ViewData["imie"] = imiee;
            return View();
        }

       [HttpPost]
       public IActionResult Send(string email,string subject,string messeage)
        {
            ViewData["subject"] = subject;
            ViewData["email"] = email;
            ViewData["messeage"] = messeage;


            return View("Privacy");

        }

      
        [HttpPost]
        public IActionResult photo()
        {

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult counter()
        {
            return View();
        }


        [HttpPost]
        public IActionResult counter(string a, string b, string cal)
        {

            double aa = Convert.ToDouble(a);
            double bb = Convert.ToDouble(b);
            double suma = 0;
            ViewData["a"] = aa;
            ViewData["b"] = bb;

            switch (cal) {
                case "Add":
                    suma = aa + bb;
                    break;
                case "Sub":
                    suma = aa - bb;
                    break;
                case "Mul":
                    suma = aa * bb;
                    break;
                case "Div":
                    suma = (double)aa / bb;
                    break;
            }

            ViewBag.result = suma;
            return View();
            
        }

        
        [ActionName("coun")]
        public IActionResult coun()
        {


            model.counting++;
            ViewData["ab"] = model.counting++;
            return View("counter");
        }

    }
}
