using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int UserId { get => UserID; set => UserID = value; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public DateTime? LastLogin { get; set; }

        public User()
        {
        }

        public User(int userid,string Username, string password,string Email, string status, DateTime lastlogin)
        {
            this.UserID = userid;
            this.Username = Username;
            this.Email = Email;
            this.Password = password;
            this.Status = status;
            this.LastLogin = lastlogin;
        }
    }
}
