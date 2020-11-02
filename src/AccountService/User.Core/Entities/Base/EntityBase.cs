using System;
using System.Collections.Generic;
using System.Text;

namespace User.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
       public virtual TId Id {get; protected set;}

    //    int? _requestedHashcode;

    //    public bool IsTransient()
    //    {
    //        return Id.Equals(TId);
    //    }

       
    //    public override bool Equals(object obj)
    //    {
    //        //
    //        // See the full list of guidelines at
    //        //   http://go.microsoft.com/fwlink/?LinkID=85237
    //        // and also the guidance for operator== at
    //        //   http://go.microsoft.com/fwlink/?LinkId=85238
    //        //
           
    //        if (obj == null || GetType() != obj.GetType())
    //        {
    //            return false;
    //        }
           
    //        // TODO: write your implementation of Equals() here
    //        throw new System.NotImplementedException();
    //        return base.Equals (obj);
    //    }
       
    //    // override object.GetHashCode
    //    public override int GetHashCode()
    //    {
    //        // TODO: write your implementation of GetHashCode() here
    //        throw new System.NotImplementedException();
    //        return base.GetHashCode();
    //    }
  }
}