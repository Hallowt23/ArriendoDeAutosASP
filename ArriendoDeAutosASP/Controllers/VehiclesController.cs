using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get List
        public IActionResult Index()
        {
            IEnumerable<Vehicle> listVehicle = _context.Vehicle;
            return View(listVehicle);
        }
        //View Create
        public IActionResult Create()
        {
            return View();
        }

        //Create Post
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicle.Add(vehicle);
                _context.SaveChanges();
                TempData["mssg"] = "Successfully added to the database";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
