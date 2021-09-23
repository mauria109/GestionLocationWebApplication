using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Service
{
    public interface IArticleService
    {
        IList<Article> Articles { get; set; }
    }
}