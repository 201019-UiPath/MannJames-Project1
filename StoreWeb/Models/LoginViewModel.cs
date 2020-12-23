using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public User User { get; set; }
    }
}
