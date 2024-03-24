using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {



        public int carPricingId { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public decimal amount { get; set; }
        public string? coverImgUrl { get; set; }


    }
}
