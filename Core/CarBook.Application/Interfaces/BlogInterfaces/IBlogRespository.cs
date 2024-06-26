﻿using CarBook.Domain.Entities;


namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRespository
    {
         Task<List<Blog>> GetLast3BlogsWithAuthors();
         Task<List<Blog>> GetAllBlogsWithAuthors();
         Task<Blog> GetBlogWithAuthor(int id);
        Task<string> ReturnBlogName(int id);
    }
}
