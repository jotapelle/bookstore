using System;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.BusinessObjects
{
    public class BookBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public List<AuthorBO> Authors { get; set; }
    }
}
