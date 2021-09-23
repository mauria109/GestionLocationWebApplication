using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("louer")]
    public class Louer
    {
        [Key]
        [Column("id_lou")]
        public int Id { get; set; }
        
        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public Location Location { get; set; }
        
        [ForeignKey("id_art")]
        [Column("id_art")]
        public Article Article{ get; set; }
        
        [Column("nombre")]
        public int Nombre { get;set; }

        public Louer()
        {
            Location = new Location();
            Article = new Article();
        }
    }
}