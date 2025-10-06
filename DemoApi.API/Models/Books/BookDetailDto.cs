namespace DemoApi.API.Models.Books;

public class BookDetailDto
{
    public int Id { get; set; }
    public string ISBN { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly Release { get; set; }
}