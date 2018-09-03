using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MagicCollection.API.Dto;
using MagicCollection.API.Models;

namespace MagicCollection.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookLite>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary.Value).Url);
                    })
                .ForMember(dest => dest.Authors, opt => {
                    opt.MapFrom(src => src.Author + (src.AuthorSort != null ? " " + src.Author2 : String.Empty));
                });
            CreateMap<Photo, PhotosDto>();
        }
    }
}
