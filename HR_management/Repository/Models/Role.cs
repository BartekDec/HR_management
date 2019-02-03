using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Role
    {
        public Role()
        {
            this.Role_Permission = new HashSet<Role_Permission>();
            this.User = new HashSet<User>();

        }
        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name:")]
        [MaxLength(25)]
        public string RoleName { get; set; }

        public virtual ICollection<Role_Permission> Role_Permission { get; set; }
        public virtual ICollection<User> User { get; set; }


    }
    
}