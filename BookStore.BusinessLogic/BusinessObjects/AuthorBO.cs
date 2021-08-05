using System.Collections.Generic;

namespace BookStore.BusinessLogic.BusinessObjects
{
    public class AuthorBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookBO> Books { get; set; }
    }
}
