using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
        public enum TypesC : int
        {
            Ekonom = 1,
            Bisness,
            Standart,
        }
        public class Types
        {
            public int Id { get; set; }
            [Required, MinLength(3)]
            public string Name { get; set; }
            [Range(0, 100_000)]
            public decimal Price { get; set; }

            public ICollection<Transport> Transports { get; set; } = new HashSet<Transport>();
        }
}
