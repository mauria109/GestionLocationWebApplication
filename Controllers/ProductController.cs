using System;
using System.Linq;
using GestionLocationWebApplication.Mapper;
using GestionLocationWebApplication.Models.Data;
using GestionLocationWebApplication.Models.Entities;
using GestionLocationWebApplication.Repository;
using GestionLocationWebApplication.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

/*namespace GestionLocationWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IArticleService _service;
        private IWebHostEnvironment webHostEnvironment;
        private IArticleMapper _articleMapper;
        private IArticleRepository ArticleRepository;

        public ProductController(IArticleService service, IWebHostEnvironment webHostEnvironment,DataContext context, IArticleMapper articleMapper, IArticleRepository articleRepository)
        {
            _service = service;
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
            _articleMapper = articleMapper;
            ArticleRepository = articleRepository;
        }
        
        // GET
        public IActionResult Index()
        {
            ViewBag.Message = "Liste des produits:";
            ChargerCategories();

            //ChargerDonnées();
           

            return View(_articleMapper.MapArticleEnArticle(_context.Articles.ToList()));
        }
        
        public IActionResult RedirectionVersIndex()
        {
            return RedirectToAction("Index");
        }
    
        public IActionResult Ajouter(Article model)
        {
            if(string.IsNullOrEmpty(model.Label)) { return View(); }
            
            //_produitContext.Add(produit);
            //_produitContext.SaveChanges();
            //var list = _produitContext.Produits.ToList();
            ////LINQ
            //var rechercheProduit = _produitContext.Produits.FirstOrDefault(p => p.Nom.Equals("Produit-:3"));

            //var rechercheProduitResultat = from p in _produitContext.Produits
            //    where p.Nom.Equals("Produit-:3")
            //    select p;

            // LINQ vers Entité
            //_produitContext.Entry(rechercheProduit)
                //.Reference(c => c.Categorie)
                //.Load();

            return RedirectToAction("Index", model);
        }

        public IActionResult Modifier(int id)
        {
            var produitModel = _service.Articles.FirstOrDefault(p => p.Id.Equals(id));
            return View(produitModel);
        }

        public IActionResult Details(int id)
        {
            var idProduit = id;
            return View();
        }
        public IActionResult Supprimer(int id)
        {
            var produitModel = _service.Articles.FirstOrDefault(p => p.Id.Equals(id));
            return View(produitModel);
        }

        public IActionResult SupprimerProduit(int id)
        {
            var produitModel = _service.Articles.FirstOrDefault(p => p.Id.Equals(id));
            _service.Articles.Remove(produitModel);
            return RedirectToAction("Index", _service.Articles);
        }

        private void ChargerCategories()
        {
            var rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                var Categorie = new Categorie
                {
                    Id = i,
                    Label = $"Categorie{i}",
                    Code = $"Description Categorie:{i}",
                };
                _context.Categories.Add(Categorie);
                _context.SaveChanges();
            }
        }
        private void ChargerDonnées()
        {
            var rnd = new Random();
            //string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //string filePath = Path.Combine(uploadsFolder, "photoModel.Titre");

            for (int i = 0; i < 40; i++)
            {
                var produit = new Article
                {
                    Id = i,
                    Description = $"C'est la description du produit numéro:{i}",
                    Quantity = 0,
                    Label = $"Produit-:{i}",
                    Prix = rnd.Next(),
                    Categorie = new Categorie
                    {
                        Id = i,
                        Label = $"Catégorie:{i}",
                        Code = $"Description Catégorie:{i}",
                    }
                };
                _context.Articles.Add(produit);
                _context.SaveChanges();
            }

           
            //    for (var i = 0; i < 40; i++)
            //    {
            //        var categorie = new Categorie
            //        {
            //            Id = i,
            //            Nom = $"Catégorie:{i}",
            //            Description = $"Description Catégorie:{i}",
            //            DateCreation = DateTime.Now
            //        };
            //        _produitContext.Categories.Add(categorie);
            //    }

            //    _produitContext.SaveChanges();
        }
    }
}*/