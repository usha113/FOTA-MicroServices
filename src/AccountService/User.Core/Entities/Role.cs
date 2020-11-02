using System;
using User.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.Serialization;

namespace User.Core.Entities
{
    public class Role : Entity
    {
      public Role()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public short Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        [JsonIgnore]
        [DataMember]
        public ICollection<UserProfile> UserProfiles { get; set; }

        
}
}
