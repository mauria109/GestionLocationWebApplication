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
    public class AchatController : Controller
    {
        private readonly DataContext _context;

        public AchatController(DataContext context)
        {
            _context = context;
        }

        // GET: Achat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Achats.ToListAsync());
        }

        // GET: Achat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // GET: Achat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achat);
        }

        // GET: Achat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achats.FindAsync(id);
            if (achat == null)
            {
                return NotFound();
            }
            return View(achat);
        }

        // POST: Achat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] Achat achat)
        {
            if (id != achat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchatExists(achat.Id))
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
            return View(achat);
        }

        // GET: Achat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // POST: Achat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var achat = await _context.Achats.FindAsync(id);
            _context.Achats.Remove(achat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchatExists(int id)
        {
            return _context.Achats.Any(e => e.Id == id);
        }
    }
}
