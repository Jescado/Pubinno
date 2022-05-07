using AutoMapper;
using Pubinno.Models;

namespace Pubinno.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationViewModel>();
            CreateMap<LocationViewModel, Location>();

            CreateMap<Location, LocationUpdateViewModel>();
            CreateMap<LocationUpdateViewModel, Location>();
        }
    }
}
