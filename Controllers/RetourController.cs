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
    public class RetourController : Controller
    {
        private readonly DataContext _context;

        public RetourController(DataContext context)
        {
            _context = context;
        }

        // GET: Retour
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retours.ToListAsync());
        }

        // GET: Retour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retour = await _context.Retours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retour == null)
            {
                return NotFound();
            }

            return View(retour);
        }

        // GET: Retour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Retour retour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retour);
        }

        // GET: Retour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retour = await _context.Retours.FindAsync(id);
            if (retour == null)
            {
                return NotFound();
            }
            return View(retour);
        }

        // POST: Retour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] Retour retour)
        {
            if (id != retour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetourExists(retour.Id))
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
            return View(retour);
        }

        // GET: Retour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retour = await _context.Retours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retour == null)
            {
                return NotFound();
            }

            return View(retour);
        }

        // POST: Retour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retour = await _context.Retours.FindAsync(id);
            _context.Retours.Remove(retour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetourExists(int id)
        {
            return _context.Retours.Any(e => e.Id == id);
        }
    }
}
