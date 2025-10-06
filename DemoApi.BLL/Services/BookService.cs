using DemoApi.BLL.Services.Interfaces;
using DemoApi.DAL.Repositories;
using DemoApi.DL.Models;

namespace DemoApi.BLL.Services;

public class BookService : IBookService
{
    private readonly BookRepository _bookRepository;

    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void Add(Book book)
    {
        _bookRepository.Add(book);
    }

    public void Delete(int id)
    {
        _bookRepository.Delete(id);
    }

    public Book GetBook(int id)
    {
        return _bookRepository.GetBook(id) ?? throw new NullReferenceException(nameof(Book));
    }

    public List<Book> GetBooks()
    {
        return _bookRepository.GetBooks();
    }

    public void Update(int id, Book book)
    {
        _bookRepository.Update(id, book);
    }
}