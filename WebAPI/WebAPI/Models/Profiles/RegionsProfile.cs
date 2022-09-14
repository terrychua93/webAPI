using AutoMapper;

namespace WebAPI.Models.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>().ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
