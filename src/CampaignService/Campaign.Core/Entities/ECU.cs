using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Campaign.Core.Entities.Base;

namespace Campaign.Core.Entities
{
    public class ECU :Entity
    {
      public ECU()
        {
         Vehicles = new HashSet<Vehicle>();   
        }

      [Key]
    public long ecu_id { get; set; }
    
    public string ecu_model { get; set; }

           
    public long ecu_type_id{get;set;}
    public ECUType ECUType{get ; set;}

    
    public long? blocks { get; set; }

    public virtual ICollection<Vehicle> Vehicles {get;set;}
    
public virtual ICollection<Campaign> Campaign {get;set;}
     
    }

}
