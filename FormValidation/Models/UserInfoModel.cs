using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Models
{
    public class UserInfoModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
       // [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        //[MinLength(2, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public int Age { get; set; }

        [Required]
       // [(1, ErrorMessage = "The {0} must be at least characters long.")]
        [Display(Name = "Gender")]

        public Char Gender { get; set; }

        [Required]
        [Display(Name = "CNIC No")]
        [DataType(DataType.CreditCard)]
        public long Cnic { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        [DataType(DataType.PhoneNumber)]
        public long HomeNo { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "User Image")]
        [DataType(DataType.Upload)]
        public string UserImage { get; set; }
    }
}