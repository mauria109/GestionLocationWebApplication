using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Service
{
    public interface ICategoryService
    {
        IList<Categorie> Categories { get; set; }
        IList<string> CategorieList { get; set; }
    }
}