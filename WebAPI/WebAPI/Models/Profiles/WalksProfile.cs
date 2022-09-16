using AutoMapper;

namespace WebAPI.Models.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>();
        }
    }
}
