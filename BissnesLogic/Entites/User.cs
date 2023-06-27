using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public class User : IdentityUser
    {
        [Required, MinLength(3)]
        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }

        public string RoleId { get; set; }
        public Roles? Role { get; set; }
        public string Token { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
