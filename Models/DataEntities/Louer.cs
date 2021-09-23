using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("louer")]
    public class Louer
    {
        [Key]
        [Column("id_lou")]
        public int Id { get; set; }
        
        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public int IdLocation { get; set; }
        
        public Entities.Location Location { get; set; }


        [ForeignKey("id_art")]
        [Column("id_art")]
        public int IdArticle
        {
            get; set;
        }
        
        public Entities.Article Article{
            get; set;
        }
        
        [Column("nombre")]
        public int Nombre
        {
            get;set;
        }

        public Louer()
        {
        }

        public Louer(int id, int idLocation, int idArticle, int nombre, Entities.Article article, Entities.Location location)
        {
            Id = id;
            Location = location;
            Article = article;
            IdArticle = idArticle;
            Nombre = nombre;
            IdLocation = idLocation;
        }
    }
}