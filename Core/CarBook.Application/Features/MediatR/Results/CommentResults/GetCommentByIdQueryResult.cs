﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.CommentResults
{
    public class GetCommentByIdQueryResult
    {
        public int CommentId { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Description { get; set; }
        public int BlogId { get; set; }
    }
}