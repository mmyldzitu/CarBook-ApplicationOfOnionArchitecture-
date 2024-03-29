﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos
{
    public class CreateCarDto
    {
        
        public int BrandId { get; set; }
        
        public string? Model { get; set; }
        public string? CoverImgUrl { get; set; }
        public int Km { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? BigImgUrl { get; set; }
      

    }
}
