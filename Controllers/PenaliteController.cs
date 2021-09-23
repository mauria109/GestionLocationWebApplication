using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionLocationWebApplication.Models.Data;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Controllers
{
    public class PenaliteController : Controller
    {
        private readonly DataContext _context;

        public PenaliteController(DataContext context)
        {
            _context = context;
        }

        // GET: Penalite
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penalites.ToListAsync());
        }

        // GET: Penalite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalite = await _context.Penalites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penalite == null)
            {
                return NotFound();
            }

            return View(penalite);
        }

        // GET: Penalite/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Penalite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Penalite penalite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penalite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penalite);
        }

        // GET: Penalite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalite = await _context.Penalites.FindAsync(id);
            if (penalite == null)
            {
                return NotFound();
            }
            return View(penalite);
        }

        // POST: Penalite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] Penalite penalite)
        {
            if (id != penalite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penalite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenaliteExists(penalite.Id))
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
            return View(penalite);
        }

        // GET: Penalite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penalite = await _context.Penalites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penalite == null)
            {
                return NotFound();
            }

            return View(penalite);
        }

        // POST: Penalite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penalite = await _context.Penalites.FindAsync(id);
            _context.Penalites.Remove(penalite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenaliteExists(int id)
        {
            return _context.Penalites.Any(e => e.Id == id);
        }
    }
}
