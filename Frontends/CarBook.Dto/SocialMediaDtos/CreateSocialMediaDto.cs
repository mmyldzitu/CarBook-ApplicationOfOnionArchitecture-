using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.SocialMediaDtos
{
    public class CreateSocialMediaDto
    {
        
        public string? name { get; set; }
        public string? url { get; set; }
        public string? iconUrl { get; set; }
    }
}
