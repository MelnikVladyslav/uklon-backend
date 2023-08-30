using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.Entites
{
    public class Transport
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Model { get; set; }

        public int TypeId { get; set; }
        public Types? Type { get; set; }

        [StringLength(255, MinimumLength = 10)]
        public string? Description { get; set; }

        [Url]
        public string ImagePath { get; set; }
    }
}
