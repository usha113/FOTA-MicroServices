using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Campaign.Core.Entities.Base;
using System.Collections.Generic;

namespace Campaign.Core.Entities
{
    public class Vehicle : Entity
    {
        
        //public int Id { get; se
       [Key]
       public long vehicle_id { get; set; }
       public string vehicle_model  { get; set; }
       public long vehicle_year  { get; set; }
       public string vehicle_registration_number  { get; set; }
       public string data_origin  { get; set; }

       //public virtual ICollection<ECU> ECUs {get;set;}

       public ECU ECU { get; set; }
      
    }
}