using DemoApi.API.Mappers;
using DemoApi.API.Models.Books;
using DemoApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<BookDetailDto>> GetBooks()
    {
        List<BookDetailDto> books = _bookService.GetBooks().ToBookDetailDtos();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult GetBook(int id)
    {
        BookDetailDto book = _bookService.GetBook(id).ToBookDetailDto();

        return Ok(book);
    }

    [HttpPost]
    public ActionResult Add([FromBody] BookDetailDto bookDto)
    {
        _bookService.Add(bookDto.ToBook());

        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] BookDetailDto bookDto)
    {
        _bookService.Update(id, bookDto.ToBook());

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _bookService.Delete(id);

        return Accepted();
    }
}