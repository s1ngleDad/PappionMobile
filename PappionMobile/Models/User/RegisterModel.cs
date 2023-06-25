using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Models.User
{
    public class RegisterModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        public int role { get; set; }
        public string password { get; set; }
        public string passwordConfirmation { get; set; }
    }
}