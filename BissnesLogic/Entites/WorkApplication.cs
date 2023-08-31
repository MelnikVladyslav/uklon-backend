using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    internal class WorkApplication
    {
        public int Id { get; set; }
        public User ApplicationUser { get; set; }
        public DateTime ApplicationDateTime { get; set; }
    }
}
