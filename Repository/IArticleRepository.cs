using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Repository
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Articles();
        void InsertArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}