using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table(("user"))]
    
    public class User
    {
        [Key]
        [Column("id_us")]
        public int IdUsr {get;set;}

        [Column("nom_us")]
        public string NomUsr {get;set;}

        [Column("prenom_us")]
        public string PrenomUsr {get;set;}

        [Column("login")]
        public string LoginUsr {get;set;}

        [Column("pwd")]
        [DataType(DataType.Password)]
        public string PwdUsr {get;set;}

        [Column("droit")]
        public string DroitUsr {get;set;}
        
        public User()
        {
        }

        public User(int idUsr, string nomUsr, string prenomUsr, string loginUsr, string pwdUsr, string droitUsr) {
            IdUsr = idUsr;
            NomUsr = nomUsr;
            PrenomUsr = prenomUsr;
            LoginUsr = loginUsr;
            PwdUsr = pwdUsr;
            DroitUsr = droitUsr;
        }
    }
}