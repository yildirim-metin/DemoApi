using DemoApi.API.Models.Books;
using DemoApi.DL.Models;

namespace DemoApi.API.Mappers;

public static class BookMappers
{
    public static BookDetailDto ToBookDetailDto(this Book book)
    {
        return new()
        {
            Id = book.Id,
            ISBN = book.ISBN,
        };
    }

    public static List<BookDetailDto> ToBookDetailDtos(this List<Book> books)
    {
        return [.. books.Select(b => b.ToBookDetailDto())];
    }

    public static Book ToBook(this BookDetailDto bookDto)
    {
        return new()
        {
            Id = bookDto.Id,
            ISBN = bookDto.ISBN,
        };
    }
}