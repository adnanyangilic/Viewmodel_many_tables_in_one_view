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
    public class LegumesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LegumesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Legumes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Legumes.ToListAsync());
        }

        // GET: Legumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legume = await _context.Legumes
                .FirstOrDefaultAsync(m => m.LegumeId == id);
            if (legume == null)
            {
                return NotFound();
            }

            return View(legume);
        }

        // GET: Legumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Legumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LegumeId,LegumeName")] Legume legume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legume);
        }

        // GET: Legumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legume = await _context.Legumes.FindAsync(id);
            if (legume == null)
            {
                return NotFound();
            }
            return View(legume);
        }

        // POST: Legumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LegumeId,LegumeName")] Legume legume)
        {
            if (id != legume.LegumeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegumeExists(legume.LegumeId))
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
            return View(legume);
        }

        // GET: Legumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legume = await _context.Legumes
                .FirstOrDefaultAsync(m => m.LegumeId == id);
            if (legume == null)
            {
                return NotFound();
            }

            return View(legume);
        }

        // POST: Legumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legume = await _context.Legumes.FindAsync(id);
            _context.Legumes.Remove(legume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegumeExists(int id)
        {
            return _context.Legumes.Any(e => e.LegumeId == id);
        }
    }
}
