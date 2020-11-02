using System;
using User.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace User.Core.Entities
{
    public class DeviceToken : Entity
    {
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DeviceTokenId { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
