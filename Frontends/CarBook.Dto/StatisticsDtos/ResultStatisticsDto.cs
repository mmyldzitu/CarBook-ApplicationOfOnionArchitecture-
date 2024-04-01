using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public string? brandName { get; set; }
        public string? brandAndModelName { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal price { get; set; }
        public int locationCount { get; set; }
        public string?  blogName { get; set; }
    }
}
