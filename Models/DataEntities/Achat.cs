using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("achat")]
    public class Achat
    {
        [Key]
        [Column("id_sh")]
        public int Id {get;set;}

        [Column("date_sh")]
        [DataType(DataType.DateTime)]
        
        public DateTime Date {get;set;}
        
        public Achat()
        {
        }


        public Achat(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}