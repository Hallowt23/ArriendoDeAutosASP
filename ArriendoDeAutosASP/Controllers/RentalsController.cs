using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;

namespace ArriendoDeAutosASP.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rental.Include(r => r.Client).Include(r => r.Office).Include(r => r.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Client)
                .Include(r => r.Office)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Client, "Id", "FirstName");
            ViewData["Id"] = new SelectList(_context.Office, "Id", "Address");
            ViewData["Id"] = new SelectList(_context.Vehicle, "Id", "Brand");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,ClientId,CarId,OfficeId,Note,PickUp")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Client, "Id", "FirstName", rental.Id);
            ViewData["Id"] = new SelectList(_context.Office, "Id", "Address", rental.Id);
            ViewData["Id"] = new SelectList(_context.Vehicle, "Id", "Brand", rental.Id);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Client, "Id", "FirstName", rental.Id);
            ViewData["Id"] = new SelectList(_context.Office, "Id", "Address", rental.Id);
            ViewData["Id"] = new SelectList(_context.Vehicle, "Id", "Brand", rental.Id);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,ClientId,CarId,OfficeId,Note,PickUp")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Client, "Id", "FirstName", rental.Id);
            ViewData["Id"] = new SelectList(_context.Office, "Id", "Address", rental.Id);
            ViewData["Id"] = new SelectList(_context.Vehicle, "Id", "Brand", rental.Id);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Client)
                .Include(r => r.Office)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rental.FindAsync(id);
            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rental.Any(e => e.Id == id);
        }
    }
}
