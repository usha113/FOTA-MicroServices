using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Campaign.Core.Entities.Base;
using Microsoft.AspNetCore.Http;

namespace Campaign.Core.Entities
{
    public class EmployeeModel : Entity
    {
        //public int Id { get; se
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long employee_id { get; set; }
       public string employee_name  { get; set; }
       public string ImageName  { get; set; }

     [NotMapped]
      public IFormFile ImageFile {get;set;}
    }
}