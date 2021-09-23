using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
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
        public int IdClient {get;set;}
        
        public Entities.Client Client {get;set;}
        
        public Reservation()
        {
        }

        public Reservation(int id, DateTime date, int idClient, Entities.Client client)
        {
            Id = id;
            Date = date;
            Client = client;
            IdClient = idClient;
        }

    }
}