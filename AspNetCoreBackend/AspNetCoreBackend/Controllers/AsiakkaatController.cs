using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBackend.Controllers
{
    public class AsiakkaatController : Controller
    {
        public IActionResult Index()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> asiakkaat = context.Customers.ToList();

            return View(asiakkaat);
        }
    }
}