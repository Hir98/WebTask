//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginReg.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class User
    {
        public int UserId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "FirstName is Requirde")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "FirstName is Requirde")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                          ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string CreatedDate { get; set; }
        public string LastLoginDate { get; set; }
        public string Status { get; set; }
        public byte[] Avatar { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public HttpPostedFileWrapper postedFile { get; set; }
        //public HttpPostedFileBase postedFile { get; set; }
        public List<User> ShowallCustomer { get; set; }

    }
}
