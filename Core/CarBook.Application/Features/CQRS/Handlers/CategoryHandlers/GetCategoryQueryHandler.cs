﻿using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {

            var entites = await _categoryRepository.GetAllAsync();
            return entites.Select(x=> new GetCategoryQueryResult { CategoryId=x.CategoryId, Name=x.Name} ).ToList();

        }

    }
}
