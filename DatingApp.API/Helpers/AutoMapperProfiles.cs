using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            // prvi parameter je destinacija (UserForDetaileDto.cs) parametra katerega bomo urejali
            // drugi parameter je parameter iz baze (source), ki ga bomo preslikali v destincaijo (PhotoUrl)
                .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            // prepiši leta v Dto s pomočjo modeal iz baze src.DateOfBirtd 
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            // za posameznika bo isto kastanje destinacije s sourcem kot je bilo za list
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                // prepiši leta v Dto s pomočjo modeal iz baze src.DateOfBirtd 
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
        }

    }
}