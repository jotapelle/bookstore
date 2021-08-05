using System;
using System.Collections.Generic;

namespace BookStore.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
