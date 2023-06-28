using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_3.Data;
using CLOUD_POE_3.Models;
using Microsoft.AspNetCore.Authorization;

namespace CLOUD_POE_3.Controllers
{
    [Authorize]

    public class RentalReturnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalReturns
        public async Task<IActionResult> Index()
        {
              return _context.RentalReturn != null ? 
                          View(await _context.RentalReturn.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RentalReturn'  is null.");
        }

        // GET: RentalReturns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.RentalReturn == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn
                .FirstOrDefaultAsync(m => m.ReturnNo == id);
            if (rentalReturn == null)
            {
                return NotFound();
            }

            return View(rentalReturn);
        }

        // GET: RentalReturns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalReturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnNo,RentalNo,ReturnDate,ElapsedDate,Fine")] RentalReturn rentalReturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalReturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalReturn);
        }

        // GET: RentalReturns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.RentalReturn == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn.FindAsync(id);
            if (rentalReturn == null)
            {
                return NotFound();
            }
            return View(rentalReturn);
        }

        // POST: RentalReturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReturnNo,RentalNo,ReturnDate,ElapsedDate,Fine")] RentalReturn rentalReturn)
        {
            if (id != rentalReturn.ReturnNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalReturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalReturnExists(rentalReturn.ReturnNo))
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
            return View(rentalReturn);
        }

        // GET: RentalReturns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.RentalReturn == null)
            {
                return NotFound();
            }

            var rentalReturn = await _context.RentalReturn
                .FirstOrDefaultAsync(m => m.ReturnNo == id);
            if (rentalReturn == null)
            {
                return NotFound();
            }

            return View(rentalReturn);
        }

        // POST: RentalReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.RentalReturn == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RentalReturn'  is null.");
            }
            var rentalReturn = await _context.RentalReturn.FindAsync(id);
            if (rentalReturn != null)
            {
                _context.RentalReturn.Remove(rentalReturn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalReturnExists(string id)
        {
          return (_context.RentalReturn?.Any(e => e.ReturnNo == id)).GetValueOrDefault();
        }
    }
}
