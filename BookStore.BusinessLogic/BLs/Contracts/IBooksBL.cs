using BookStore.BusinessLogic.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.BLs.Contracts
{
    public interface IBooksBL
    {
        Task<int> Add(BookBO bookBO);
        Task<List<BookBO>> GetList();
        Task Remove(int idBook);
    }
}