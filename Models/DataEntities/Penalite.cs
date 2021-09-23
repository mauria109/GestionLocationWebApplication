using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("penalite")]
    public class Penalite
    {
        [Key]
        [Column("id_pen")]
        public int Id {get;set;}

        [Column("date_pen")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get;set;}
        public Penalite()
        {
        }

        public Penalite(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        
        
        
    }
}