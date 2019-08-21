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
                .ForMember(n => n.NewsId, options => options.Ignore());

            CreateMap<ApplicationUser, ApplicationUserVM>()
                .ReverseMap()
                .ForMember(n => n.Id, options => options.Ignore());
        }
    }
}
