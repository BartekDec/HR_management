using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User : IdentityUser
    {


        [Required]
        [Display(Name ="User Name:")]
        [MaxLength(25)]
        public string Login { get; set; }

        [Required]
        [Display(Name ="Passwprd")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}