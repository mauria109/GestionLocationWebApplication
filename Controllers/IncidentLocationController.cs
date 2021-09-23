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
    public class IncidentLocationController : Controller
    {
        private readonly DataContext _context;

        public IncidentLocationController(DataContext context)
        {
            _context = context;
        }

        // GET: IncidentLocation
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncidentLocations.Include(il => il.Incident).Include(il =>il.Location).Include(il =>il.Achat).AsNoTracking().ToListAsync());
        }

        // GET: IncidentLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentLocation = await _context.IncidentLocations.Include(il => il.Incident).Include(il =>il.Location).Include(il =>il.Achat).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentLocation == null)
            {
                return NotFound();
            }

            return View(incidentLocation);
        }

        // GET: IncidentLocation/Create
        public IActionResult Create()
        {
            ViewBag.Incident = ListInc();
            ViewBag.Location = ListLoc();
            ViewBag.Achat = ListShop();
            return View();
        }

        // POST: IncidentLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeIncident")] IncidentLocation incidentLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidentLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Incident = ListInc();
            ViewBag.Location = ListLoc();
            ViewBag.Achat = ListShop();
            return View(incidentLocation);
        }

        // GET: IncidentLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentLocation = await _context.IncidentLocations.FindAsync(id.ToString());
            if (incidentLocation == null)
            {
                return NotFound();
            }
            ViewBag.Incident = ListInc();
            ViewBag.Location = ListLoc();
            ViewBag.Achat = ListShop();
            return View(incidentLocation);
        }

        // POST: IncidentLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeIncident")] IncidentLocation incidentLocation)
        {
            if (id != incidentLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentLocationExists(incidentLocation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Incident = ListInc();
                ViewBag.Location = ListLoc();
                ViewBag.Achat = ListShop();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentLocation);
        }

        // GET: IncidentLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentLocation = await _context.IncidentLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentLocation == null)
            {
                return NotFound();
            }

            return View(incidentLocation);
        }
        
        
        private IEnumerable<SelectListItem> ListInc()
        {
            return _context.Incidents.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Date.ToString()
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
        
        private IEnumerable<SelectListItem> ListShop()
        {
            return _context.Achats.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Date.ToString()
            }).ToList();
        }


        // POST: IncidentLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentLocation = await _context.IncidentLocations.FindAsync(id.ToString());
            _context.IncidentLocations.Remove(incidentLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentLocationExists(int id)
        {
            return _context.IncidentLocations.Any(e => e.Id == id);
        }
    }
}
