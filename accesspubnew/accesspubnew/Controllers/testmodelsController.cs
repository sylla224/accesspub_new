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
    public class testmodelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public testmodelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: testmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.testmodel.ToListAsync());
        }

        // GET: testmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmodel = await _context.testmodel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testmodel == null)
            {
                return NotFound();
            }

            return View(testmodel);
        }

        // GET: testmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: testmodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom")] testmodel testmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testmodel);
        }

        // GET: testmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmodel = await _context.testmodel.FindAsync(id);
            if (testmodel == null)
            {
                return NotFound();
            }
            return View(testmodel);
        }

        // POST: testmodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom")] testmodel testmodel)
        {
            if (id != testmodel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!testmodelExists(testmodel.ID))
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
            return View(testmodel);
        }

        // GET: testmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmodel = await _context.testmodel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testmodel == null)
            {
                return NotFound();
            }

            return View(testmodel);
        }

        // POST: testmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testmodel = await _context.testmodel.FindAsync(id);
            _context.testmodel.Remove(testmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool testmodelExists(int id)
        {
            return _context.testmodel.Any(e => e.ID == id);
        }
    }
}
