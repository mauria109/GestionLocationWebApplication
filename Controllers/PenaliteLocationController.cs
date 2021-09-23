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
    public class PenaliteLocationController : Controller
    {
        private readonly DataContext _context;

        public PenaliteLocationController(DataContext context)
        {
            _context = context;
        }

        // GET: PenaliteLocation
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenaliteLocations.Include(pl => pl.Location).Include(pl => pl.Article).AsNoTracking().ToListAsync());
        }

        // GET: PenaliteLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penaliteLocation = await _context.PenaliteLocations.Include(p => p.Location).Include(p => p.Article)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penaliteLocation == null)
            {
                return NotFound();
            }

            return View(penaliteLocation);
        }

        // GET: PenaliteLocation/Create
        public IActionResult Create()
        {
            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View();
        }

        // POST: PenaliteLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] PenaliteLocation penaliteLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penaliteLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View(penaliteLocation);
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

        // GET: PenaliteLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penaliteLocation = await _context.PenaliteLocations.FindAsync(id);
            if (penaliteLocation == null)
            {
                return NotFound();
            }
            ViewBag.Location = ListLoc();
            ViewBag.Article = ListArt();
            return View(penaliteLocation);
        }

        // POST: PenaliteLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] PenaliteLocation penaliteLocation)
        {
            if (id != penaliteLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penaliteLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenaliteLocationExists(penaliteLocation.Id))
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
            return View(penaliteLocation);
        }

        // GET: PenaliteLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penaliteLocation = await _context.PenaliteLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penaliteLocation == null)
            {
                return NotFound();
            }

            return View(penaliteLocation);
        }

        // POST: PenaliteLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penaliteLocation = await _context.PenaliteLocations.FindAsync(id);
            _context.PenaliteLocations.Remove(penaliteLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenaliteLocationExists(int id)
        {
            return _context.PenaliteLocations.Any(e => e.Id == id);
        }
    }
}
