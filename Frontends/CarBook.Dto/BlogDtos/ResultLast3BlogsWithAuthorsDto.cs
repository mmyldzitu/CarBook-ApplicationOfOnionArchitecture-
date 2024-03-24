﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos
{
    public class ResultLast3BlogsWithAuthorsDto
    {


        public int blogId { get; set; }
        public string? title { get; set; }
        public int authorId { get; set; }
        public string? authorName { get; set; }
        public string? coverImg { get; set; }
        public DateTime createDate { get; set; }
        public int categoryId { get; set; }


    }
}
