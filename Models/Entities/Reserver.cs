using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("reserver")]
    public class Reserver
    {
        [Key]
        [Column("id_resv")]
        public int Id {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public Article Article {get;set;}

        [ForeignKey("id_res")]
        [Column("id_res")]
        public Reservation Reservation {get;set;}

        [Column("nombre")]
        public int Nombre {get;set;}

        public Reserver()
        {
            Article = new Article();
            Reservation = new Reservation();
        }
        

        
        
        
    }
}