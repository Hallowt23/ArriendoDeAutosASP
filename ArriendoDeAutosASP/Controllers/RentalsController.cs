using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get List
        public IActionResult IndexVehicle()
        {
            IEnumerable<Rental> listRental = _context.Rental;
            return View(listRental);
        }
        //View Create
        public IActionResult CreateRental()
        {
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRental(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Rental.Add(rental);
                _context.SaveChanges();
                TempData["mssg"] = "Successfully added to the database";

                return RedirectToAction("IndexRental");
            }
            return View();
        }
        //View Edit
        public IActionResult EditRental(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rental = _context.Rental.Find(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }
        //Edit Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRental(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Rental.Update(rental);
                _context.SaveChanges();
                TempData["mssg"] = "Success";

                return RedirectToAction("IndexRental");
            }
            return View();
        }
        //View Delete
        public IActionResult DeleteRental(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rental = _context.Rental.Find(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }
        //Delete Vehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveRental(int? id)
        {
            var rental = _context.Rental.Find(id);
            if (rental == null)
            {
                return NotFound();
            }
            _context.Rental.Remove(rental);
            _context.SaveChanges();
            TempData["mssg"] = "Deleted";
            return RedirectToAction("IndexRental");
        }
    }
}
