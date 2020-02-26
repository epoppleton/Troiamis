using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Troiamis.Models
{
    public class User
    {
        string userName { get; set; }
        string password { get; set; }
        string userEmail { get; set; }
        int age { get; set; }
        public string avatarImageString { get; set; }
    }
}
