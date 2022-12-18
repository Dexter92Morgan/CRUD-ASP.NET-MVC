//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Registerlogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Employee
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public  string Gender { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter salary")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Enter Only Numbers")]
        public Nullable<decimal> Salary { get; set; }

       

    }
}
