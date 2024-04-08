using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRespository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetCarDailyPricing(int id)
        {
            var value = await _context.CarPricings.Where(x => x.CarId == id && x.PricingId == 2).FirstOrDefaultAsync();
            if (value != null)
            {
                return value.Amount;
            }
            return 0;
        }

        public async Task<List<CarPricing>> GetCarPricings(int id)
        {

            
                var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x!.Brand).Include(x => x.Pricing).Where(x => x.PricingId == id).ToListAsync();


            return values;

        }
    }
}
