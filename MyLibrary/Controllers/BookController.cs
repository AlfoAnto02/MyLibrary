using Application.Abstractions.Services;
using Application.Factories;
using Application.Models.DTOs;
using Application.Models.Request;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase {

        public readonly IBookService _bookService;
        public readonly IBookCategoryService _bookCategoryService;

        public BookController(IBookService bookService, IBookCategoryService _bookCategoryService) {
            this._bookService = bookService;
            this._bookCategoryService = _bookCategoryService;
        }

        /*[HttpGet("get")]
        public async Task<IActionResult> GetBooksAsync() {
            var booksDtos = new List<BookDTO>();
            foreach (var book in await _bookService.GetAllAsync()) {
                booksDtos.Add(new BookDTO(book));
            }

            var getBooksResponse = new GetEntitiesResponse<BookDTO> {
                Entities = booksDtos
            };
            return Ok(ResponseFactory.WithSuccess(getBooksResponse));
        }


          [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetBookAsync(int id) {
            try {
                var book = await _bookService.GetAsync(id);
                var getSingleBookResponse = new EntityResponse<BookDTO>() {
                    Result = new BookDTO(book)
                };
                return Ok(new BookDTO(book));
            }catch (Exception e) {
                return NotFound(ResponseFactory.WithError(e));
            }
        }*/

        [HttpPost("add")]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookRequest bookRequest) {
            try {
                var book = bookRequest.ToEntity();
                await _bookCategoryService.AddBookCategoryRelationAsync(book, bookRequest.CategoriesIds);
                await _bookService.AddAsync(book);
                var entityResponse = new EntityResponse<BookDTO>() {
                    Result = new BookDTO(book)
                };
                return Ok(ResponseFactory.WithSuccess(entityResponse));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookRequest book) {
            try {
                var newBook = await _bookService.UpdateBookAsync(book.bookToUpdateId, book.Book.ToEntity(), book.Book.CategoriesIds);
                var updateBookResponse = new EntityResponse<BookDTO>() {
                    Result = new BookDTO(newBook)
                };
                return Ok(updateBookResponse);
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
        [HttpPost("filterBy")]
        public async Task<IActionResult> FilterBy([FromBody] SearchRequest filterRequest) {
            var books = await _bookService.GetByFilterAsync(filterRequest);
            var booksDtos = new List<BookDTO>();
            foreach (var book in books.Result) {
                booksDtos.Add(new BookDTO(book));
            }
            var response = new GetByFilterResponse() {
                Books = booksDtos,
                pageSize = (int)Math.Ceiling(books.TotalNum / (decimal)filterRequest.Pagination.PageSize)
            };
            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteBookAsync(int id) {
            try {
                await _bookService.DeleteBookAsync(id);
                return Ok(ResponseFactory.WithSuccess("Book deleted with success"));
            }
            catch (Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
    }
}
