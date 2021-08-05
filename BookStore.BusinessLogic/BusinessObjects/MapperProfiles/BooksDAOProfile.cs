using AutoMapper;
using BookStore.DataAccess.Entities;
using System.Linq;

namespace BookStore.BusinessLogic.BusinessObjects.MapperProfiles
{
    public class BooksDAOProfile : Profile
    {
        public BooksDAOProfile()
        {
            CreateMap<BookBO, Book>()
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
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(s => s.Authors.Select(a => new Author { Id = a.Id })));
        }
    }
}
