using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Controllers
{
    public class OfficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get List
        public IActionResult IndexOffice()
        {
            IEnumerable<Office> listOffice = _context.Office;
            return View(listOffice);
        }
        //View Create
        public IActionResult CreateOffice()
        {
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOffice(Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Office.Add(office);
                _context.SaveChanges();
                TempData["mssg"] = "Successfully added to the database";

                return RedirectToAction("IndexOffice");
            }
            return View();
        }
        //View Edit
        public IActionResult EditOffice(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var office = _context.Office.Find(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }
        //Edit Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOffice(Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Office.Update(office);
                _context.SaveChanges();
                TempData["mssg"] = "Success";

                return RedirectToAction("IndexOffice");
            }
            return View();
        }
        //View Delete
        public IActionResult DeleteOffice(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var office = _context.Office.Find(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }
        //Delete Office
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveOffice(int? id)
        {
            var office = _context.Office.Find(id);
            if (office == null)
            {
                return NotFound();
            }
            _context.Office.Remove(office);
            _context.SaveChanges();
            TempData["mssg"] = "Deleted";
            return RedirectToAction("IndexOffice");
        }
    }
}
