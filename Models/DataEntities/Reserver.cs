using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("reserver")]
    public class Reserver
    {
        [Key]
        [Column("id_resv")]
        public int Id {get;set;}

        [ForeignKey("id_art")]
        [Column("id_art")]
        public int IdArticle {get;set;}
        
        public Entities.Article Article {get;set;}

        [ForeignKey("id_res")]
        [Column("id_res")]
        public int IdReservation {get;set;}
        
        public Entities.Reservation Reservation {get;set;}

        
        public int Nombre {get;set;}
        
        public Reserver() {
            
        }


        public Reserver(int id, int idArticle, int nombre, int idReservation, Entities.Article article, Entities.Reservation reservation)
        {
            Id = id;
            Article = article;
            Nombre = nombre;
            Reservation = reservation;
            IdArticle = idArticle;
            IdReservation = idReservation;
        }

        
        
        
    }
}