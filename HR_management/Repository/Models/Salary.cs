using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Salary
    {
        public Salary()
        {
            this.Employee = new HashSet<Employee>();
        }  
        
        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Amount:")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Currency:")]
        [MaxLength(3)]
        public string Currency { get; set; }

        [Required]
        public int EmploymentTypeId { get; set; }

        public virtual EmploymentType EmploymentType { get; set; }

        public virtual ICollection<Employee> Employee { get; set; } 
    }
}