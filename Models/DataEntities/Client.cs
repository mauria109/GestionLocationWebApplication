using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("client")]
    
    public class Client
    {
        [Key]
        [Column("id_cli")]
        public int Id {get;set;}

        [Column("nom_cli")]
        public string Nom {get;set;}

        [Column("prenom_cli")]
        public string Prenom {get;set;}

        [Column("tel")]
        [DataType(DataType.PhoneNumber)]
        public int Tel {get;set;}

        [Column("cni")]
        public string Ci {get;set;}
        
        public Client()
        {
        }

        public Client(int id, string nom, string prenom, int tel, string ci)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Ci = ci;
        }
    }
}