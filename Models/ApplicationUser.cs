using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name="FullName")]
        public String FullName { get; set; }
    }
}
