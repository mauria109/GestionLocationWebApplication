using System.Collections.Generic;
using System.Linq;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Service
{
    public class CategoryService : ICategoryService
    {
        public IList<Categorie> Categories { get; set; }
        public IList<string> CategorieList { get; set; }


        public CategoryService()
        {
            Categories = ListCategorie();
            CategorieList = ListCategorieLabel();
        }

        private IList<Categorie> ListCategorie()
        {
            var listCategorie = new List<Categorie>();
            for (var i = 0; i < 50; i++)
            {
                var categorie = new Categorie
                {
                    Id = i,
                    Code = $"Code:{i}",
                    Label = $"Catégorie:{i}"
                };
                listCategorie.Add(categorie);
            }

            return listCategorie;
        }


        private IList<string> ListCategorieLabel()
        {
            var categories = Categories?.Select(c => c.Label).ToList();
            return categories;
        }
    }
}