using System;
using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Service
{
    public class ArticleService : IArticleService
    {
        public IList<Article> Articles { get; set; }

        public ArticleService()
        {
            Articles = ListArticles();
        }

        private IList<Article> ListArticles()
        {
            var article = new List<Article>();

            var rnd = new Random();
            for (var i = 0; i < 50; i++)
            {
                var articles = new Article
                {
                    Id = i,
                    Categorie = new Categorie
                    {
                        Code = $"Code:{i}",
                        Id = i,
                        Label = $"Catégorie:{i}"
                    },
                    Description = $"Description article:{i}",
                    Label = $"Libellé article:{i}",
                    Prix = rnd.Next(),
                    Quantity = 0
                };
                article.Add(articles);
            }

            return article;
        }
    }
}