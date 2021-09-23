using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("reservation")]
    
    public class Reservation
    {
        [Key]
        [Column("id_res")]
        public int Id {get;set;}

        [Column("date_res")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get;set;}

        [ForeignKey("id_cli")]
        [Column("id_cli")]
        public Client Client {get;set;}
        
        public Reservation()
        {
            Client = new Client();
        }

    }
}