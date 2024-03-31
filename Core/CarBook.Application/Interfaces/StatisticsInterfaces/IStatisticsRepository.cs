using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogsCount();
        int GetBrandsCount();
        Task<decimal> GetDailyAveragePrice();
        Task<decimal> GetWeeklyAveragePrice();
        Task<decimal> GetMonthlyAveragePrice();
        int GetCarCountByTransmissionIsAuto();
        Task<string >GetMostCountBrand();
        Task<string >GetMostCommentBlog();
        int GetCarCountByKmLessThan1000();
        int GetCarCountByGasolineOrDiesel();
        int GetCarCountByElectric();
        Task<string >GetBrandAndModelDailyPriceIsMax();
        Task<string >GetBrandAndModelDailyPriceIsMin();
    }
}
