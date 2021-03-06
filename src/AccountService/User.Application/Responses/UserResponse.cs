using System;
using User.Core.Entities;
using System.Collections.Generic;

namespace User.Application.Responses
{
    public class UserResponse
    {
        
         public long UserId { get; set; }
       public string UserName { get; set; }
       public string Email { get; set; }
       public short Status { get; set; }
       public short? IsActive { get; set; }
       public short? FailureAttempt { get; set; } = 0;
       public long? CreatedBy { get; set; }
       public DateTime CreatedOn { get; set; }
       public long? LastModifiedBy { get; set; }
       public DateTime ModifiedOn { get; set; }

        public Byte[] PasswordHash { get; set; }

        public Byte[] SaltHash { get; set; }

        public Role Role { get; set; }

        public string Token { get; set; }
        public string Password { get; set; }
        
        public string NewPassword { get; set; }
        
        public string EmailComputed { get;set;  }
        

        public DeviceToken DeviceToken { get; set; }

            }
}
