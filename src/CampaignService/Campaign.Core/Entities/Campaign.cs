using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Campaign.Core.Entities.Base;


namespace Campaign.Core.Entities
{
    public class Campaign : Entity
    {
        //public int Id { get; se
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long campaign_id { get; set; }
       public string campaign_name  { get; set; }
       public string campaign_desc  { get; set; }

//public long approver_id {get;set;}
public Approver Approver  { get; set; }
      
//public long vehiclegroup_id{get;set;}
       public VehicleGroup VehicleGroup{get ; set;}

//public long firmware_id{get;set;}
       public Firmware Firmware {get; set;}

       //public long ecu_id{get;set;}
       public ECU ECU{get ; set;}

       
       public DateTime campaign_start_date { get; set; }
       public DateTime campaign_end_date { get; set; }
       public bool is_active { get; set; }
       public DateTime approval_date  { get; set; }
       public short? approval_status { get; set; }
public short status { get; set; }
       

      
    }
}