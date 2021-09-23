using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("location")]
    public class Location
    {
        [Key]
        [Column("id_loc")]
        public int Id { get; set; }

        [Column("date_loc")]
        public DateTime DateLoc { get; set; }

        [Column("date_ret")]
        public DateTime DateRet { get; set; }
        
        [ForeignKey("id_cli")]
        [Column("id_cli")]
        public Client Client { get; set; }

        [Column("delay")]
        [DataType(DataType.Duration)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int Duree { get; set; }

        [Column("retour")]
        public bool Retourner { get; set; }

        [ForeignKey("id_us")]
        [Column("id_us")]
        public User User { get; set; }


        public Location()
        {
            Client = new Client();
            User = new User();
        }
    }
}