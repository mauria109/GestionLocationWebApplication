using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("categorie")]
    public class Categorie
    {
        [Key]
        [Column("id_cat")]
        public int Id {get;set;}

        [Column("label_cat")]
        public string Label {get;set;}

        [Column("code_cat")]
        public string Code {get;set;}

    }
}