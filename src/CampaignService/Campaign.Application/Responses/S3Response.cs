using System;
using Campaign.Core.Entities;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Campaign.Application.Responses
{
    public class S3Response
    {
        public HttpStatusCode Status{get;set;}

        public string Message {get;set;}
    }
}