using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArriendoDeAutosASP.Controllers
{
    
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public BillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bills
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bill.Include(b => b.Rental);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bills/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Rental)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["RentId"] = new SelectList(_context.Rental, "Id", "Id");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentId,Iva,Total,Date,Active")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RentId"] = new SelectList(_context.Rental, "Id", "Id", bill.RentId);
            bill.Date = DateTime.Now;
            return View(bill);
        }

        //AutoBill
        public async Task<IActionResult> AutoCreate([Bind("Id,RentId,Iva,Total,Date,Active")] Bill bill)
        {
            var applicationDbContext = _context.Bill.Include(b => b.Rental);
            int iva = 5990;
            var r = new Random();
            ViewData["total"] = bill.Total;
            ViewData["rentid"] = bill.RentId;
            bill.Id = r.Next(0,9990999);
            bill.Date = DateTime.Now; bill.Active = "AutoBill";
            bill.Iva = iva;
            foreach (var item in applicationDbContext)
            {
                if (item.RentId == bill.RentId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RentId"] = new SelectList(_context.Rental, "Id", "Id", bill.RentId);
            return View(bill);
        }

        // GET: Bills/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["RentId"] = new SelectList(_context.Rental, "Id", "Id", bill.RentId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentId,Iva,Total,Date,Active")] Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
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
            ViewData["RentId"] = new SelectList(_context.Rental, "Id", "Id", bill.RentId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Rental)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.Id == id);
        }
    }
}
