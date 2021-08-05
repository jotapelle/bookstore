using AutoMapper;
using BookStore.BusinessLogic.BusinessObjects;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.ViewModels.MapperProfiles
{
    public class BooksVMProfile : Profile
    {
        public BooksVMProfile()
        {
            CreateMap<BookBO, BookVM>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Title)
                )
                .ForMember(dest =>
                    dest.ISBN,
                    opt => opt.MapFrom(src => src.ISBN)
                )
                .ForMember(dest =>
                    dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate)
                )
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(s => s.Authors.Select(a => new AuthorVM { Id = a.Id, Name = a.Name }).ToList()));
        }
    }
}
