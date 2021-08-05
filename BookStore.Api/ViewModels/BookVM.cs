using System;
using System.Collections.Generic;

namespace BookStore.Api.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public List<AuthorVM> Authors { get; set; }
    }
}
