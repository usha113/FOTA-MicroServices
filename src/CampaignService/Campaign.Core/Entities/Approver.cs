using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Campaign.Core.Entities.Base;
using System.Text;
using System.Collections.Generic;


namespace Campaign.Core.Entities
{
    public class Approver : Entity
    {
        
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long approver_id { get; set; }
       public string approver_name  { get; set; }
      
      
    
        public ICollection<Campaign> Campaign { get; set; }
    }
}