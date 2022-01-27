using AutoMapper;

namespace JRovnySiteManager.Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.EntityFramework.Models.Image, Models.Image>();
        }
    }
}