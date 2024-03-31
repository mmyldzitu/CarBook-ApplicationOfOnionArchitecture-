using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public int GetBlogsCount()
        {
            return _context.Blogs.Count();
        }

        public async Task< string> GetBrandAndModelDailyPriceIsMax()
        {
            var pricingId = await _context.Pricings.Where(x => x.PricingName == "Günlük").Select(x => x.PricingId).SingleOrDefaultAsync();
            var maxCarPricing = await _context.CarPricings.Where(x => x.PricingId == pricingId).MaxAsync(x => x.Amount);
            var car = await _context.Cars.Include(x=>x.Brand).Where(x => x.CarPricings!.Any(x => x.Amount == maxCarPricing)).FirstOrDefaultAsync();
            if (car != null)
            {
                return $"{car.Brand!.BrandName}- {car.Model}";

            }
            return String.Empty;
        }

        public string GetBrandAndModelDailyPriceIsMin()
        {
            throw new NotImplementedException();
        }

        public int GetBrandsCount()
        {
            return _context.Brands.Count();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByElectric()
        {
            return _context.Cars.Where(x => x.Fuel == "Electric").Count();

        }

        public int GetCarCountByGasolineOrDiesel()
        {
            return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel=="Diesel").Count();

        }

        public int GetCarCountByKmLessThan1000()
        {
            return _context.Cars.Where(x=>x.Km<1000).Count();
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            return _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
        }

        public async Task<decimal> GetDailyAveragePrice()
        {
            int id = await _context.Pricings.Where(x => x.PricingName == "Günlük").Select(x => x.PricingId).SingleOrDefaultAsync();
            var result = await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(x => x.Amount);
            return result;
        }

        public int GetLocationCount()
        {
           return _context.Locations.Count();
        }

        public async Task<decimal> GetMonthlyAveragePrice()
        {
            int id = await _context.Pricings.Where(x => x.PricingName == "Aylık").Select(x => x.PricingId).SingleOrDefaultAsync();
            var result = await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(x => x.Amount);
            return result;
        }

        public async Task<string>GetMostCommentBlog()
        {
            int maxVal = await _context.Blogs.MaxAsync(x => x.Comments!.Count());
            var blog = await _context.Blogs.Where(x => x.Comments!.Count() == maxVal).FirstOrDefaultAsync();
            if (blog != null)
            {
                return blog.Title!;
            }
            return string.Empty;
        }

        public async Task<string >GetMostCountBrand()
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetWeeklyAveragePrice()
        {
            int id = await _context.Pricings.Where(x => x.PricingName == "Haftalık").Select(x => x.PricingId).SingleOrDefaultAsync();
            var result = await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(x => x.Amount);
            return result;
        }
    }
}
