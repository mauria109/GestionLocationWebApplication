using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.Entities
{
    [Table("incident_location")]
    public class IncidentLocation
    {
        [Key]
        [Column("id_inc_loc")]
        public int Id {get;set;}

        [ForeignKey("id_inc")]
        [Column("id_inc")]
        public Incident Incident { get; set; }

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public Location Location { get; set; }

        [ForeignKey("id_sh")]
        [Column("id_sh")]
        public Achat Achat { get; set; }
        
        public string TypeIncident {get;set;}

        public IncidentLocation()
        {
            Incident = new Incident();
            Location = new Location();
            Achat = new Achat();
        }
    }
}