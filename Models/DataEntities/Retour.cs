using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("retour")]
    public class Retour
    {
        [Key]
        [Column("id_ret")]
        public int Id {get;set;}

        [Column("date_ret")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get;set;}
        
        public Retour()
        {
        }

        public Retour(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        
        
        
        
    }
}