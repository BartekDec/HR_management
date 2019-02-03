using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }
        
        [Required]
        [Display (Name = "Name:")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname:")]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Phone:")]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "email:")]
        [MaxLength(25)]
        public string Email { get; set; }

        [Required]
        public int SalaryId { get; set; }

        public virtual Salary Salary { get; set; }


    }
}