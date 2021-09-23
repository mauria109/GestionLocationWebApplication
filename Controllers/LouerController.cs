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
    public class LouerController : Controller
    {
        private readonly DataContext _context;

        public LouerController(DataContext context)
        {
            _context = context;
        }

        // GET: Louer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Louer.Include(l => l.Location).Include(l => l.Article).AsNoTracking().ToListAsync());
        }

        // GET: Louer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var louer = await _context.Louer.Include(l => l.Location).Include(l => l.Article).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (louer == null)
            {
                return NotFound();
            }

            return View(louer);
        }

        // GET: Louer/Create
        public IActionResult Create()
        {
            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View();
        }

        // POST: Louer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Louer louer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(louer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View(louer);
        }
        
        
        private IEnumerable<SelectListItem> ListArt()
        {
            return _context.Articles.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Label
            }).ToList();
        }
        
        private IEnumerable<SelectListItem> ListLoc()
        {
            return _context.Locations.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Duree.ToString()
            }).ToList();
        }
        
        // GET: Louer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var louer = await _context.Louer.FindAsync(id);
            if (louer == null)
            {
                return NotFound();
            }
            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View(louer);
        }

        // POST: Louer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Louer louer)
        {
            if (id != louer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(louer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LouerExists(louer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Location = ListLoc();
                ViewBag.Article = ListArt();
                return RedirectToAction(nameof(Index));
            }
            return View(louer);
        }

        // GET: Louer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var louer = await _context.Louer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (louer == null)
            {
                return NotFound();
            }

            return View(louer);
        }

        // POST: Louer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var louer = await _context.Louer.FindAsync(id);
            _context.Louer.Remove(louer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LouerExists(int id)
        {
            return _context.Louer.Any(e => e.Id == id);
        }
    }
}
