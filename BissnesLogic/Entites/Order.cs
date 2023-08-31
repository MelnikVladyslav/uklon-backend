using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public User? User { get; set; }
        public int Rating { get; set; }
        public IEnumerable<Transport> Transports { get; set; } = new HashSet<Transport>();
    }
}
