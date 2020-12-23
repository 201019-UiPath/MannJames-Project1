using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.ComponentModel;

namespace StoreWeb.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public List<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        public enum UserType
        {
            Customer,
            Manager
        }
        public User()
        {
            Cart = new Cart();
        }
    }
}
