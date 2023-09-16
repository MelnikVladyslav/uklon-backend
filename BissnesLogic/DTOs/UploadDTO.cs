using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissnesLogic.DTOs
{
    public class UploadDTO
    {
        public string userId { get; set; }
        public IFormFile imageFile { get; set; }
    }
}
