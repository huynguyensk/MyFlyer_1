using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MyFlyer.Model.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }

        public static implicit operator Task<object>(AppRole v)
        {
            throw new NotImplementedException();
        }
    }
}