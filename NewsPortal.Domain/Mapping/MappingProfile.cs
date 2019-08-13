using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;

namespace NewsPortal.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<News, NewsVM>()
                .ReverseMap()
                .ForMember(j => j.NewsId, options => options.Ignore());
        }
    }
}
