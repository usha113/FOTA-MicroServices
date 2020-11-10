using System;
using Campaign.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Core.Entities
{
    public class VehicleGroup : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long vehiclegroup_id { get; set; }
    
        public string Vehiclegroup_name { get; set; }
        public  ICollection<Campaign> Campaign {get;set;}
    }
}
