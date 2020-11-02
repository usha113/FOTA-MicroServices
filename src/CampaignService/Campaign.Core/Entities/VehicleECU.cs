using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Campaign.Core.Entities.Base;

namespace Campaign.Core.Entities
{
    public class VehicleECU : Entity
    {
        //public int Id { get; se
       [Key]
       public long vehicle_ecu_id { get; set; }

       [ForeignKey(nameof(ECU))]
        public long ecu_id  { get; set; }

        [ForeignKey(nameof(Vehicle))]
       public long vehicle_id { get; set; }
       
    }
}