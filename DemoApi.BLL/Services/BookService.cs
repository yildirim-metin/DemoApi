using DemoApi.BLL.Services.Interfaces;
using DemoApi.DAL.Models;

namespace DemoApi.BLL.Services;

public class BookService : IBookService
{
    private int NextId = 0;
    private List<Book> Books =
    [
        new Book { Id = 1, ISBN = "978-0451524935", Title = "1984", Description = "A dystopian novel by George Orwell.", Release = new DateOnly(1949, 6, 8) },
        new Book { Id = 2, ISBN = "978-0141439600", Title = "Pride and Prejudice", Description = "A classic romance by Jane Austen.", Release = new DateOnly(1813, 1, 28) },
        new Book { Id = 3, ISBN = "978-0747532743", Title = "Harry Potter and the Philosopher's Stone", Description = "The first book in the Harry Potter series.", Release = new DateOnly(1997, 6, 26) },
        new Book { Id = 4, ISBN = "978-0061120084", Title = "To Kill a Mockingbird", Description = "A novel about racial injustice in the Deep South.", Release = new DateOnly(1960, 7, 11) },
        new Book { Id = 5, ISBN = "978-0553382563", Title = "A Game of Thrones", Description = "The first book in the epic fantasy series A Song of Ice and Fire.", Release = new DateOnly(1996, 8, 6) },
        new Book { Id = 6, ISBN = "978-0307277671", Title = "The Road", Description = "A post-apocalyptic novel by Cormac McCarthy.", Release = new DateOnly(2006, 9, 26) },
        new Book { Id = 7, ISBN = "978-0261103573", Title = "The Fellowship of the Ring", Description = "The first volume of The Lord of the Rings.", Release = new DateOnly(1954, 7, 29) },
        new Book { Id = 8, ISBN = "978-0060850524", Title = "Brave New World", Description = "A futuristic novel exploring a controlled society.", Release = new DateOnly(1932, 1, 1) },
        new Book { Id = 9, ISBN = "978-0385472579", Title = "The Alchemist", Description = "A philosophical tale about destiny and dreams.", Release = new DateOnly(1988, 5, 1) },
        new Book { Id = 10, ISBN = "978-0156012195", Title = "The Little Prince", Description = "A poetic tale about love, loss, and childhood.", Release = new DateOnly(1943, 4, 6) }
    ];

    public void Add(Book book)
    {
        book.Id = NextId++;
        Books.Add(book);
    }

    public void Delete(int id)
    {
        Books.Remove(GetBook(id));
    }

    public Book GetBook(int id)
    {
        return Books.First(b => b.Id == id);
    }

    public List<Book> GetBooks()
    {
        return Books;
    }

    public void Update(int id, Book book)
    {
        Book bookToUpdate = GetBook(id);
        bookToUpdate = book;
    }
}