﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsTop5WithBrand()
        {
            var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarId).Take(5).ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetCarsWithBrand()
        {
            var list = await _context.Cars.Include(x=>x.Brand).ToListAsync();
            return list;
        }

        public Task<List<Car>> GetCarsWithPricings()
        {
            throw new NotImplementedException();
        }
       
        
    }
}
