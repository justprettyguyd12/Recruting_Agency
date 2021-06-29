using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }

        //public string Surname { get; set; }
    }
}
