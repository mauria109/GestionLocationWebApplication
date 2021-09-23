using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionLocationWebApplication.Models.Data;
using GestionLocationWebApplication.Models.Entities;
using MySql.Data.MySqlClient;

namespace GestionLocationWebApplication.Controllers
{
    public class ArticleController : Controller
    {
        private readonly DataContext _context;

        public ArticleController(DataContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.Include(a => a.Categorie).AsNoTracking().ToListAsync());
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.Include(art => art.Categorie).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            //PopulateCategories();
            ViewBag.Categorie = ListCats();
            return View();
            /*var categories = PopulateCategories();
            return View(new SelectList(categories, "Id", "Label"));*/
        }
        
        /*private static List<Categorie> PopulateCategories()
        {
            var categories = new List<Categorie>();
            var cons = @"server=127.0.0.1;port=3306;user=root;password=;database=location_web_app";
            using (var con = new MySqlConnection(cons))
            {
                var querry = "SELECT * FROM categorie";
                using (var cmd = new MySqlCommand(querry))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            categories.Add(new Categorie
                            {
                                Label = sdr["Label"].ToString(),
                                Id = Convert.ToInt32(sdr["Id"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return categories;
        }*/

        /*private void PopulateCategories(object selectedCategory = null)
        {
            var query = from c in _context.Categories orderby c.Label select c;
            Debug.Assert(true, nameof(query) + " != null");
            //query.ToList();
            ViewBag.Categorie = new SelectList(query.AsNoTracking(), "Id", "label", selectedCategory);
        }*/

        private IEnumerable<SelectListItem> ListCats()
        {
            return _context.Categories.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Label
            }).ToList();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Description,Prix,Quantity")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorie = ListCats();
            return View(article);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id.ToString());
            if (article == null)
            {
                return NotFound();
            }
            ViewBag.Categorie = ListCats();
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,Description,Prix,Quantity")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Categorie = ListCats();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id.ToString());
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
