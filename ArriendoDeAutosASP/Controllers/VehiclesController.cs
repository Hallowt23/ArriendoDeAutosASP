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
        [ValidateAntiForgeryToken]
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
        //View Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        //Edit Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicle.Update(vehicle);
                _context.SaveChanges();
                TempData["mssg"] = "Success";

                return RedirectToAction("Index");
            }
            return View();
        }
        //View Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        //Delete Vehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVehicle(int? id)
        {
            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();
            TempData["mssg"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}
