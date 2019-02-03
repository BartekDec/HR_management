using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Permission
    {
        public Permission()
        {
            this.Role_Permission = new HashSet<Role_Permission>();
        }

        [Key]
        [Display(Name ="Id:")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name:")]
        [MaxLength(25)]
        public string PermName { get; set; }

        public virtual ICollection<Role_Permission> Role_Permission { get; set; }

    }
}