using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
         

   string created_by { get; set; }
         DateTime created_on { get; set; }
         string last_modified_by { get; set; }
         DateTime modified_on { get; set; }
    }
}