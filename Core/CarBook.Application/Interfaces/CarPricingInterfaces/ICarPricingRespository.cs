﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRespository
    {
        Task<List<CarPricing>> GetCarPricings(int id);
        Task<decimal> GetCarDailyPricing(int id);
    }
}
