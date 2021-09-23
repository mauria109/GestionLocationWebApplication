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
    public class ReserverController : Controller
    {
        private readonly DataContext _context;

        public ReserverController(DataContext context)
        {
            _context = context;
        }

        // GET: Reserver
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservers.Include(rs=> rs.Article).Include(rs=> rs.Reservation).AsNoTracking().ToListAsync());
        }

        // GET: Reserver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserver = await _context.Reservers.Include(rs=> rs.Article).Include(rs=> rs.Reservation).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserver == null)
            {
                return NotFound();
            }

            return View(reserver);
        }
        
        private IEnumerable<SelectListItem> ListArt()
        {
            return _context.Articles.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Label
            }).ToList();
        }
        
        private IEnumerable<SelectListItem> ListRev()
        {
            return _context.Reservations.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Date.ToString()
            }).ToList();
        }

        // GET: Reserver/Create
        public IActionResult Create()
        {
            ViewBag.Article = ListArt();
            ViewBag.Reservation = ListRev();
            return View();
        }

        // POST: Reserver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Reserver reserver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Article = ListArt();
            ViewBag.Reservation = ListRev();
            return View(reserver);
        }

        // GET: Reserver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserver = await _context.Reservers.FindAsync(id);
            if (reserver == null)
            {
                return NotFound();
            }
            ViewBag.Article = ListArt();
            ViewBag.Reservation = ListRev();
            return View(reserver);
        }

        // POST: Reserver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Reserver reserver)
        {
            if (id != reserver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserverExists(reserver.Id))
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
            return View(reserver);
        }

        // GET: Reserver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserver = await _context.Reservers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserver == null)
            {
                return NotFound();
            }

            return View(reserver);
        }

        // POST: Reserver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserver = await _context.Reservers.FindAsync(id);
            _context.Reservers.Remove(reserver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserverExists(int id)
        {
            return _context.Reservers.Any(e => e.Id == id);
        }
    }
}
