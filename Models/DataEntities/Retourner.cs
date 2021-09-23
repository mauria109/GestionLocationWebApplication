using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("retourner")]
    
    public class Retourner
    {
        [Key]
        [Column("id_re")]
        public int Id {get;set;}

        [Column("id_ret")]
        public Entities.Retour Retour {get;set;}

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public int Location {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public int IdArticle {get;set;}
        
        public Entities.Article Article {get;set;}

        [Column("nombre")]
        public int Nombre {get;set;}
        
        public Retourner()
        {
        }

        public Retourner(int id, Entities.Retour retour, int location, int idArticle, int nombre, Entities.Article article)
        {
            Id = id;
            Retour = retour;
            Location = location;
            Article = article;
            Nombre = nombre;
            IdArticle = idArticle;
        }

        
        
    }
}