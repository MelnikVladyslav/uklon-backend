using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public enum TypesD : int
    {
        Full = 1,
        Driver,
        Partner,
        Client,
        Corporation
    }

    public class Roles : IdentityRole
    {
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
