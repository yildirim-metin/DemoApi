using DemoApi.DAL.Models;

namespace DemoApi.BLL.Services.Interfaces;

public interface IBookService
{
    public List<Book> GetBooks();
    public Book GetBook(int id);
    public void Add(Book book);
    public void Update(int id, Book book);
    public void Delete(int id);
}
