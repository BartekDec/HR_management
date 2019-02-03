using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class EmploymentType
    {
        public EmploymentType()
        {
            this.Salary = new HashSet<Salary>();
        }

        [Key]
        [Display(Name ="Id:")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tax:")]
        public decimal Tax { get; set; }

        [Required]
        [Display(Name ="Name:")]
        [MaxLength(20)]
        public string EmpTypeName { get; set; }

        public virtual ICollection<Salary> Salary { get; set; }


    }
}