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
    public class ECUType : Entity
    {
        //public int Id { get; se
       [Key]
       
       public long ecu_type_id { get; set; }
       public string ecu_type_name  { get; set; }
      
      public ICollection<ECU> ECU {get; set;}
    
      
    }
}