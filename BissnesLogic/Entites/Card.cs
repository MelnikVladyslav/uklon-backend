using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
