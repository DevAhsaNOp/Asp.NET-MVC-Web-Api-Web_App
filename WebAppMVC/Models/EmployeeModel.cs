using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}