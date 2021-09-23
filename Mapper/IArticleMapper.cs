using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Mapper
{
    public interface IArticleMapper
    {
        public Article MapArticleEnArticle(Article model);
        public Categorie MapCategorieEnCategorie(Categorie model);
        public IList<Article> MapArticlesEnArticles(List<Article> articles);
    }
}