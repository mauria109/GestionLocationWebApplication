using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("incident")]
    public class Incident
    {
        [Key]
        [Column("id_inc")]
        public int Id {get;set;}

        [Column("date_inc")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get;set;}


    }
}