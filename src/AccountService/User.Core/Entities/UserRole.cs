using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace User.Core.Entities
{
    public class UserRole
    {

      [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserRoleId { get; set; }
    
    [ForeignKey(nameof(UserProfile))]
    public long UserId { get; set; }
    
    [ForeignKey(nameof(Role))]
    public long RoleId { get; set; }
    public short Status { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public long? LastModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }

    }
}
