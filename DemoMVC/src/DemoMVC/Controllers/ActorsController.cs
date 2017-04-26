using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Controllers
{
    public class ActorsController : Controller
    {
        private ActorDbContext _context;
        public ActorsController(ActorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actors actors)
        {
            //kui mudeli olek on kehtiv siis
            if (ModelState.IsValid)
            {
                //lisateks näitlejad
                _context.Actors.Add(actors);
                //salvestatakse
                _context.SaveChanges();
                //suunatakse tagasi Indexi lehele
                return RedirectToAction("Index");
            }
            //kui pole kehtiv, siis tagastame näitlejate vaate
            return View(actors);
        }
    }
}
