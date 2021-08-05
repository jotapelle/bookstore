using BookStore.DataAccess.Context;
using BookStore.DataAccess.DAOs.Contracts;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.DAOs.Implementations
{
    public class BooksDAO : IBooksDAO
    {
        private readonly BookStoreContext _bookStoreContext;

        public BooksDAO(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<int> Add(Book book)
        {

            _bookStoreContext.Books.Add(book);
            await _bookStoreContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task Remove(int idBook)
        {
            Book book = _bookStoreContext.Books.FirstOrDefault(b => b.Id == idBook);
            _bookStoreContext.Books.Remove(book);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetList() => await _bookStoreContext.Books.ToListAsync();

    }
}
