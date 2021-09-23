using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("penalite_location")]
    public class PenaliteLocation
    {
        [Key]
        [Column("id_pen_loc")]
        public int Id {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public Article Article {get;set;}

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public Location Location {get;set;}

        public PenaliteLocation()
        {
            Article = new Article();
            Location = new Location();
        }
        
    }
}