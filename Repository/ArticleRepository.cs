using System.Collections.Generic;
using GestionLocationWebApplication.Models.Data;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Article> Articles()
        {
            return _context.Articles;
            //throw new System.NotImplementedException();
        }

        public void InsertArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            //throw new System.NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
            //throw new System.NotImplementedException();
        }
    }
}