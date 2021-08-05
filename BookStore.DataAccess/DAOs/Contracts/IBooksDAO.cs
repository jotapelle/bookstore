using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.DAOs.Contracts
{
    public interface IBooksDAO
    {
        Task<int> Add(Book book);
        Task<List<Book>> GetList();
        Task Remove(int idBook);
    }
}