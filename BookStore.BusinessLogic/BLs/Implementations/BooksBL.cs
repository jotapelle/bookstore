using AutoMapper;
using BookStore.BusinessLogic.BLs.Contracts;
using BookStore.BusinessLogic.BusinessObjects;
using BookStore.BusinessLogic.BusinessObjects.MapperProfiles;
using BookStore.DataAccess.DAOs.Contracts;
using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.BLs.Implementations
{
    public class BooksBL : IBooksBL
    {
        private readonly IBooksDAO _booksDAO;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        public BooksBL(IBooksDAO booksDAO)
        {
            _booksDAO = booksDAO;
            _mapperConfiguration = new MapperConfiguration(m =>
            {
                m.AddProfile<BooksBOProfile>();
                m.AddProfile<BooksDAOProfile>();
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public async Task<int> Add(BookBO bookBO)
        {
            Book bookDB = _mapper.Map<Book>(bookBO);
            int id = await _booksDAO.Add(bookDB);
            return id;
        }

        public async Task Remove(int idBook)
        {
            await _booksDAO.Remove(idBook);
        }

        public async Task<List<BookBO>> GetList()
        {
            List<Book> booksDB = await _booksDAO.GetList();
            List<BookBO> booksBO = _mapper.Map<List<BookBO>>(booksDB);
            return booksBO;
        }
    }
}
