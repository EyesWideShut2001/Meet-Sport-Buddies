using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap <AppUser, MemberDto>()
            .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url))
            .ForMember(dest => dest.Sports, opt => opt.MapFrom(src => src.Sports));
        CreateMap <Photo, PhotoDto>();
        CreateMap <Sport, SportDto>();
    }

}