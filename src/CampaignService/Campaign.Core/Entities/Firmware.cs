using System;
using Campaign.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.Serialization;



namespace Campaign.Core.Entities
{
    public class Firmware : Entity
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long firmware_id { get; set; }
        public string firmware_Name { get; set; }
        public string current_firmware_version { get; set; }
        public string current_firmware_link { get; set; }
        public string previous_firmware_version { get; set; }
        public string previous_firmware_link { get; set; }
        

        public ICollection<Campaign> Campaign {get;set;}

        
}
}
