﻿using System;
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
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
              return _context.Car != null ? 
                          View(await _context.Car.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Car'  is null.");
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.CarNo == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarNo,CarMake,Model,BodyType,KilometresTravelled,ServiceKilometres,Avaliable")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CarNo,CarMake,Model,BodyType,KilometresTravelled,ServiceKilometres,Avaliable")] Car car)
        {
            if (id != car.CarNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarNo))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.CarNo == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Car'  is null.");
            }
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
          return (_context.Car?.Any(e => e.CarNo == id)).GetValueOrDefault();
        }
    }
}
