using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
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
        

        
        
        
        
    }
}