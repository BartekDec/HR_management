using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Role_Permission
    {
        public Role_Permission()
        {

        }
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }

    }
}