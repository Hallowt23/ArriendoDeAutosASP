﻿using ArriendoDeAutosASP.Data;
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
        public IActionResult IndexVehicle()
        {
            IEnumerable<Vehicle> listVehicle = _context.Vehicle;
            return View(listVehicle);
        }
        //View Create
        public IActionResult CreateVehicle()
        {
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicle.Add(vehicle);
                _context.SaveChanges();
                TempData["mssg"] = "Successfully added to the database";

                return RedirectToAction("IndexVehicle");
            }
            return View();
        }
        //View Edit
        public IActionResult EditVehicle(int? id)
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
        public IActionResult UpdateVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicle.Update(vehicle);
                _context.SaveChanges();
                TempData["mssg"] = "Success";

                return RedirectToAction("IndexVehicle");
            }
            return View();
        }
        //View Delete
        public IActionResult DeleteVehicle(int? id)
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
        public IActionResult RemoveVehicle(int? id)
        {
            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();
            TempData["mssg"] = "Deleted";
            return RedirectToAction("IndexVehicle");
        }
    }
}
