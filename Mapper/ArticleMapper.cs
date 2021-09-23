using System;
using System.Collections.Generic;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Mapper
{
    public class ArticleMapper : IArticleMapper
    {
        public Article MapArticleEnArticle(Article model)
        {
            return new Article
            {
                Categorie = MapCategorieEnCategorie(model.Categorie),
                Description = model.Description,
                Id = model.Id,
                Label = model.Label,
                Prix = model.Prix,
                Quantity = model.Quantity
            };
            //throw new System.NotImplementedException();
        }
        
        
        public Article MapArticle(Article art)
        {
            return new Article
            {
                Categorie = MapCategorieEnCategorie(art.Categorie),
                Description = art.Description,
                Id = art.Id,
                Label = art.Label,
                Prix = art.Prix,
                Quantity = art.Quantity
            };
            //throw new System.NotImplementedException();
        }

        public Categorie MapCategorieEnCategorie(Categorie model)
        {
            return new Categorie
            {
                Code = model.Code,
                Label = model.Label,
                Id = model.Id
            };
            //throw new System.NotImplementedException();
        }
        
        public Categorie MapCategorie(Categorie cat)
        {
            return new Categorie
            {
                Code = cat.Code,
                Label = cat.Label,
                Id = cat.Id
            };
            //throw new System.NotImplementedException();
        }

        public IList<Article> MapArticlesEnArticles(List<Article> articles)
        {
            var article = new List<Article>();
            articles.ForEach(a =>
            {
                var art = MapArticle(a);
                article.Add(art);
            });
            //throw new System.NotImplementedException();
            return article;
        }
    }
}