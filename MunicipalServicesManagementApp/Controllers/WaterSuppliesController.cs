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
    public class WaterSuppliesController : Controller
    {
        private readonly MunicipalDbContext _context;

        public WaterSuppliesController(MunicipalDbContext context)
        {
            _context = context;
        }

        // GET: WaterSupplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterSupplies.ToListAsync());
        }

        // GET: WaterSupplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterSupply == null)
            {
                return NotFound();
            }

            return View(waterSupply);
        }

        // GET: WaterSupplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zone,Consumption,LastUpdated")] WaterSupply waterSupply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterSupply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterSupply);
        }

        // GET: WaterSupplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies.FindAsync(id);
            if (waterSupply == null)
            {
                return NotFound();
            }
            return View(waterSupply);
        }

        // POST: WaterSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zone,Consumption,LastUpdated")] WaterSupply waterSupply)
        {
            if (id != waterSupply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterSupply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterSupplyExists(waterSupply.Id))
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
            return View(waterSupply);
        }

        // GET: WaterSupplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterSupply == null)
            {
                return NotFound();
            }

            return View(waterSupply);
        }

        // POST: WaterSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterSupply = await _context.WaterSupplies.FindAsync(id);
            if (waterSupply != null)
            {
                _context.WaterSupplies.Remove(waterSupply);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterSupplyExists(int id)
        {
            return _context.WaterSupplies.Any(e => e.Id == id);
        }
    }
}
