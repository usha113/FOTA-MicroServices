using System;
using Campaign.Core.Entities;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Campaign.Application.Responses
{
    public class EmployeeResponse
    {
        
             public long employee_id { get; set; }
       public string employee_name  { get; set; }
       public string ImageName  { get; set; }


       public IFormFile ImageFile {get;set;}

            }
}
