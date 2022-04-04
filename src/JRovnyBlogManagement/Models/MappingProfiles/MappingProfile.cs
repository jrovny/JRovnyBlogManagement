using AutoMapper;

namespace JRovny.BlogManagement.Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.EntityFramework.Models.Image, Models.Image>();
            CreateMap<Data.Models.PostDetailView, Models.PostDetailView>();
            CreateMap<Data.Models.PostSummary, Models.PostSummary>();
        }
    }
}