using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MunicipalServicesManagementApp.Models;

namespace MunicipalServicesManagementApp.Controllers
{
    public class ParkManagementsController : Controller
    {
        private readonly MunicipalDbContext _context;

        public ParkManagementsController(MunicipalDbContext context)
        {
            _context = context;
        }

        // GET: ParkManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkManagements.ToListAsync());
        }

        // GET: ParkManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkManagement = await _context.ParkManagements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkManagement == null)
            {
                return NotFound();
            }

            return View(parkManagement);
        }

        // GET: ParkManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParkName,Location,IsOpen")] ParkManagement parkManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkManagement);
        }

        // GET: ParkManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkManagement = await _context.ParkManagements.FindAsync(id);
            if (parkManagement == null)
            {
                return NotFound();
            }
            return View(parkManagement);
        }

        // POST: ParkManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkName,Location,IsOpen")] ParkManagement parkManagement)
        {
            if (id != parkManagement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkManagementExists(parkManagement.Id))
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
            return View(parkManagement);
        }

        // GET: ParkManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkManagement = await _context.ParkManagements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkManagement == null)
            {
                return NotFound();
            }

            return View(parkManagement);
        }

        // POST: ParkManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkManagement = await _context.ParkManagements.FindAsync(id);
            if (parkManagement != null)
            {
                _context.ParkManagements.Remove(parkManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkManagementExists(int id)
        {
            return _context.ParkManagements.Any(e => e.Id == id);
        }
    }
}
