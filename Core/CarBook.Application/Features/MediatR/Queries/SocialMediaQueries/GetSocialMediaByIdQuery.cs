﻿using CarBook.Application.Features.MediatR.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery:IRequest<GetSocialMediaByIdQueryResult>
    {
        public int SocialMediaId { get; set; }

        public GetSocialMediaByIdQuery(int socialMediaId)
        {
            SocialMediaId = socialMediaId;
        }
    }
}
