using System;
using Campaign.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;


namespace Campaign.Core.Entities
{
    public class Firmware : Entity
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long firmware_id { get; set; }
        public string firmware_name { get; set; }
        public string new_firmware_version { get; set; }
        public string new_firmware_link { get; set; }
        public string old_firmware_version { get; set; }
        public string old_firmware_link { get; set; }
        

        public ICollection<Campaign> Campaign {get;set;}

        public string newFirmwareZipName{get;set;}
        [NotMapped]
        public IFormFile newFirmwareZipFile{get;set;}

        //[NotMapped]
        //public IFormFile OldFirmwareFile{get;set;}
}
}
