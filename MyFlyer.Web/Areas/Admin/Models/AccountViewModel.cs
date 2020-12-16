using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.Areas.Admin.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Email { get; set; }
        public RoleViewModel Role { get; set; }
        public bool IsActive { get; set; }
    }
}
