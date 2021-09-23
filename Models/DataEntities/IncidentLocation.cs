using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionLocationWebApplication.Models.DataEntities
{
    [Table("incident_location")]
    public class IncidentLocation
    {
        [Key]
        [Column("id_inc_loc")]
        public int Id {get;set;}

        [ForeignKey("id_inc")]
        [Column("id_inc")]
        public int IdIncident {get;set;}
        
        public Entities.Incident Incident { get; set; }

        [ForeignKey("id_loc")]
        [Column("id_loc")]
        public int IdLocation {get;set;}
        
        public Location Location { get; set; }

        [ForeignKey("id_sh")]
        [Column("id_sh")]
        public int IdAchat {get;set;}
        
        public Entities.Achat Achat { get; set; }
        
        [Column("type_inc")]
        public string TypeIncident {get;set;}


        public IncidentLocation() {}

        public IncidentLocation(int id, int idIncident, int idLocation,int idAchat, string typeIncident, Entities.Incident incident, Entities.Achat achat, Location location)
        {
            Id = id;
            Incident = incident;
            IdIncident = idIncident;
            Location = location;
            IdLocation = idLocation;
            Achat = achat;
            IdAchat = idAchat;
            TypeIncident = typeIncident;
        }
    }
}