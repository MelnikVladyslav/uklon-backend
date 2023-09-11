using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public class SelAdress
    {
        public int Id { set; get; }
        public string NameAdr { set; get; }
        public string NameHome { set; get; }
        public string NameJob { set; get; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
