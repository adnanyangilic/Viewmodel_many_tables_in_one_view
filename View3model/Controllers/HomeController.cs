using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using View3model.Data;
using View3model.Models;
using View3model.ViewModels;

namespace View3model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var veggy = new VeggyVM
            {
                Fruits = _context.Fruits.ToList(),
                Vegetables = _context.Vegetables.ToList(),
                Legumes = _context.Legumes.ToList(),
                Grains = _context.Grains.ToList()
            };

            return View(veggy);
        }

        [HttpPost]
        public IActionResult Create(VeganVM vegan)
        {
            Fruit fru = new Fruit();
            fru.FruitName = vegan.FruitName;
            _context.Fruits.Add(fru);
            _context.SaveChanges();

            Vegetable veg = new Vegetable();
            veg.VegetableName = vegan.VegetableName;
            _context.Vegetables.Add(veg);
            _context.SaveChanges();

            Legume legu = new Legume();
            legu.LegumeName = vegan.LegumeName;
            _context.Legumes.Add(legu);
            _context.SaveChanges();


            Grain gra = new Grain();
            gra.GrainName = vegan.GrainName;
            _context.Grains.Add(gra);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Create()
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
