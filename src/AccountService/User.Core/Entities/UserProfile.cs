using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class UserProfile : Entity
    {
        //public int Id { get; se
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        #region Ignore Changes
        [JsonIgnore]
        [DisplayName("Password Hashed")]
        public Byte[] PasswordHash { get; set; }

        [JsonIgnore]
        [DisplayName("Password Salt")]
        public Byte[] SaltHash { get; set; }

        public Role Role { get; set; }

        #endregion

        #region Non Mapping Fields
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string NewPassword { get; set; }
        [NotMapped]
        public string EmailComputed { get => string.IsNullOrEmpty(this.Email) ? null : this.Email.ToLowerInvariant();  }
        #endregion

        public DeviceToken DeviceToken { get; set; }

    }
}