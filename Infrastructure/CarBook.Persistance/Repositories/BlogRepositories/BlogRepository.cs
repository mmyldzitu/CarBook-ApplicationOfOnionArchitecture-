﻿using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRespository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {

            var values = await _context.Blogs.Include(x=>x.Author).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();

            return values;
        }
        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {

            var values = await _context.Blogs.Include(x => x.Author).Include(x=>x.Category).ToListAsync();

            return values;
        }
    }
}
