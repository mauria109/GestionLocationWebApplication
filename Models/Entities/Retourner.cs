using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("retourner")]
    
    public class Retourner
    {
        [Key]
        [Column("id_re")]
        public int Id {get;set;}

        [ForeignKey("id_ret")]
        [Column("id_ret")]
        public Retour Retour {get;set;}

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public Location Location {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public Article Article {get;set;}

        [Column("nombre")]
        public int Nombre {get;set;}
        
        public Retourner()
        {
            Retour = new Retour();
            Location = new Location();
            Article = new Article();
        }

    }
}