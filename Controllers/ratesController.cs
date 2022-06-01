using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using accesspubnew.Data;
using accesspubnew.Models;

namespace accesspubnew.Controllers
{
    public class ratesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ratesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: rates
        public async Task<IActionResult> Index()
        {
            return View(await _context.rate.ToListAsync());
        }

        // GET: rates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.rate
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,rate_code,rate_achat,rate_vente,date_jour")] rate rate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: rates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.rate.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }
            return View(rate);
        }

        // POST: rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,rate_code,rate_achat,rate_vente,date_jour")] rate rate)
        {
            if (id != rate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rateExists(rate.ID))
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
            return View(rate);
        }

        // GET: rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.rate
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rate = await _context.rate.FindAsync(id);
            _context.rate.Remove(rate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rateExists(int id)
        {
            return _context.rate.Any(e => e.ID == id);
        }
    }
}
