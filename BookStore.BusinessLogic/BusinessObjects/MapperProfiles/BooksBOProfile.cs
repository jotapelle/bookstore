using AutoMapper;
using BookStore.DataAccess.Entities;
using System.Linq;

namespace BookStore.BusinessLogic.BusinessObjects.MapperProfiles
{
    public class BooksBOProfile : Profile
    {
        public BooksBOProfile()
        {
            CreateMap<Book, BookBO>()
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
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(s => s.Authors.Select(a => new AuthorBO { Id = a.Id, Name = a.Name }).ToList()));
        }
    }
}
