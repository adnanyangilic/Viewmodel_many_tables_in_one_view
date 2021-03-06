using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using View3model.Data;
using View3model.Models;

namespace View3model.Controllers
{
    public class GrainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grains.ToListAsync());
        }

        // GET: Grains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grains
                .FirstOrDefaultAsync(m => m.GrainId == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // GET: Grains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrainId,GrainName")] Grain grain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grain);
        }

        // GET: Grains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grains.FindAsync(id);
            if (grain == null)
            {
                return NotFound();
            }
            return View(grain);
        }

        // POST: Grains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrainId,GrainName")] Grain grain)
        {
            if (id != grain.GrainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrainExists(grain.GrainId))
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
            return View(grain);
        }

        // GET: Grains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grains
                .FirstOrDefaultAsync(m => m.GrainId == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // POST: Grains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grain = await _context.Grains.FindAsync(id);
            _context.Grains.Remove(grain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrainExists(int id)
        {
            return _context.Grains.Any(e => e.GrainId == id);
        }
    }
}
