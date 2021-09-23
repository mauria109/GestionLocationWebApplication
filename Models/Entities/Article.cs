using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("article")]
    public sealed class Article
    {
        [Key]
        [Column("id_art")]
        public int Id {get; set;}

        [Column("label_art")]
        public string Label {get;set;}

        [Column("desc_art")]
        public string Description {get;set;}

        [Column("pu_art")]
        public float Prix {get;set;}

        [Column("quantity")]
        public int Quantity {get;set;}
        
        [ForeignKey("id_cat")]
        [Column("id_cat")]
        //[NotMapped]
        public Categorie Categorie { get; set; }

        
        public Article()
        {
            Categorie = new Categorie();
        }



    }
}