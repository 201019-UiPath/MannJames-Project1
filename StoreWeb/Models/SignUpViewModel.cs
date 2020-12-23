using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb.Models
{
    public class SignUpViewModel
    {
        [DataType(DataType.Text)]
        [DisplayName("Username")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Name")]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<SelectListItem> LocationOptions { get; set; }
    }
}