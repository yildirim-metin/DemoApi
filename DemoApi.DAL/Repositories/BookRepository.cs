using DemoApi.DAL.Utils;
using DemoApi.DL.Models;
using Microsoft.Data.SqlClient;

namespace DemoApi.DAL.Repositories;

public class BookRepository
{
    private readonly string _connectionString;

    public BookRepository()
    {
        _connectionString = EnvironmentFileReader.GetConnectionString();
    }

    public List<Book> GetBooks()
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        SELECT *
        FROM Book
        ";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        List<Book> books = [];
        while (reader.Read())
        {
            books.Add(MapEntity(reader));
        }
        return books;
    }

    public Book? GetBook(int id)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        SELECT *
        FROM Book
        WHERE id = @id
        ";

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        return reader.Read() ? MapEntity(reader) : null;
    }

    public void Add(Book book)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        INSERT INTO Book (Id, ISBN, Title, Description, Release)
        VALUES (@id, @isbn, @title, @description, @release)
        ";

        command.Parameters.AddWithValue("@id", book.Id);
        command.Parameters.AddWithValue("@isbn", book.ISBN);
        command.Parameters.AddWithValue("@title", book.Title);
        command.Parameters.AddWithValue("@description", book.Description);
        command.Parameters.AddWithValue("@release", book.Release);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Update(int id, Book book)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        UPDATE Book
        SET ISBN = @isbn, Title = @title, Description = @description, Release = @release
        WHERE id = @id
        ";

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@isbn", book.ISBN);
        command.Parameters.AddWithValue("@title", book.Title);
        command.Parameters.AddWithValue("@description", book.Description);
        command.Parameters.AddWithValue("@release", book.Release);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = connection.CreateCommand();

        command.CommandText = @"
        DELETE FROM Book WHERE id = @id
        ";

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        command.ExecuteNonQuery();
    }

    private static Book MapEntity(SqlDataReader reader)
    {
        return new()
        {
            Id = (int)reader["Id"],
            ISBN = (string)reader["ISBN"],
            Title = (string)reader["Title"],
            Description = (string)reader["Description"],
            Release = (DateOnly)reader["Release"],
        };
    }
}