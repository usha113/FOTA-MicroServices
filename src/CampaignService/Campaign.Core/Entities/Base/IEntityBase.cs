using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
          long? CreatedBy { get; set; }
         DateTime CreatedOn { get; set; }
         long? LastModifiedBy { get; set; }
         DateTime ModifiedOn { get; set; }

    }
}