using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcUserInfoModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MinLength(3)]
        [RegularExpression("^([A-z][A-Za-z]*\\s+[A-Za-z]*)|([A-z][A-Za-z]*)$", ErrorMessage = "Please enter valid First Name")]
        public string FirstName { get; set; }
        [MinLength(3)]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^([A-z][A-Za-z]*\\s+[A-Za-z]*)|([A-z][A-Za-z]*)$", ErrorMessage = "Please enter valid Last Name")]
        public string LastName { get; set; }
        [MinLength(3)]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter valid Email ID")]
        public string Email { get; set; }
        [MinLength(10)]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("(^[0-9]{10}$)|(^\\+[0-9]{2}\\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Please enter valid Phone number")]
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}