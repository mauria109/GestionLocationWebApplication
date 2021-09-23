using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("penalite_location")]
    public class PenaliteLocation
    {
        [Key]
        [Column("id_pen_loc")]
        public int Id {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public int IdArticle {get;set;}
        
        
        public Entities.Article Article {get;set;}

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public int IdLocation {get;set;}
        
        public Entities.Location Location {get;set;}
        
        public PenaliteLocation()
        {
        }


        public PenaliteLocation(int id, int idArticle, int idLocation, Entities.Article article, Entities.Location location)
        {
            Id = id;
            Article = article;
            Location = location;
            IdArticle = idArticle;
            IdLocation = idLocation;
        }
        
        

        
        
        
    }
}