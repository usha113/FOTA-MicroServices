using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaign.Application.Responses;
using Campaign.Core.Entities;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace Campaign.Application.Commands
{
    public class EmployeeCommand : IRequest<EmployeeResponse>
    {
        
      public long employee_id { get; set; }
       public string employee_name  { get; set; }
       public string ImageName  { get; set; }


       public IFormFile ImageFile {get;set;}


    }
}