using AutoMapper;
using BookStore.Api.ViewModels;
using BookStore.Api.ViewModels.MapperProfiles;
using BookStore.BusinessLogic.BLs.Contracts;
using BookStore.BusinessLogic.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStoreController : ControllerBase
    {
        private readonly IBooksBL _booksBL;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        public BookStoreController(IBooksBL booksBL)
        {
            _booksBL = booksBL;
            _mapperConfiguration = new MapperConfiguration(m =>
            {
                m.AddProfile<BooksBOProfile>();
                m.AddProfile<BooksVMProfile>();
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooks()
        {
            List<BookVM> result = _mapper.Map<List<BookVM>>(await _booksBL.GetList());
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddBook(BookVM book)
        {
            BookBO bookBO = _mapper.Map<BookBO>(book);
            await _booksBL.Add(bookBO);
            return Ok();
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _booksBL.Remove(id);
            return Ok();
        }        
    }
}
