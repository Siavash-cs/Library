using Library.Tables;
using Microsoft.Data.SqlClient;

namespace Library.Repositories;

public class BookRepository
{
    private readonly DataBase _database;

    public BookRepository()
    {
        _database = new DataBase();
    }


    public void Insert(Book book)
    {
        const string insertCmd =
            @"INSERT INTO [Book]([ISBN],[Title],[Author],[Publishyear],[Category]) VALUES (@ISBN,@Title,@Author,@publishyear,@Catagory)" ;
        var command = new SqlCommand(insertCmd, _database.Connection);
        
        command.Parameters.AddWithValue("ISBN", book.ISBN);
        command.Parameters.AddWithValue("Author", book.Author);
        command.Parameters.AddWithValue("Publishyear", book.Publishyear);
        command.Parameters.AddWithValue("Title", book.Title);
        command.Parameters.AddWithValue("Catagory", book.Category);
        command.ExecuteNonQuery();
    }

    public void Update(Book book)
    {
        var command = new SqlCommand(
            "UPDATE [Book] SET [ISBN]=@ISBN , [Author] =@Author ,[Publishyear]=@Publishyear,[Title]=@Title ,[Category]=@Category WHERE [BookID] = @BookID", 
            _database.Connection);
     
        command.Parameters.AddWithValue("BookID", book.BookID);
        command.Parameters.AddWithValue("ISBN", book.ISBN);
        command.Parameters.AddWithValue("Author", book.Author);
        command.Parameters.AddWithValue("Publishyear", book.Publishyear);
        command.Parameters.AddWithValue("Title", book.Title);
        command.Parameters.AddWithValue("Category", book.Category);
        command.ExecuteNonQuery();
    }

    public void Delete(Book book)
    {
        var command = new SqlCommand("DELETE FROM [BOOK] WHERE BookID = @BookID", _database.Connection);
        command.Parameters.AddWithValue("BookID",book.BookID);
        command.ExecuteNonQuery();
    }

    public IList<Book> SelectAll()
    {
        var result = new List<Book>();
        var command = new SqlCommand("SELECT * FROM [Book]",_database.Connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
           result.Add(FromReader(reader));
        }
        return result;
    }

    public List<Book> GetById(int id)
    {
        var book = new List<Book>();
        var command = new SqlCommand("SELECT * FROM [Book] WHERE [BookID] = @BookID",_database.Connection);
        command.Parameters.AddWithValue("BookID", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
             book.Add(FromReader(reader)) ;
        }

        return book;
    }
    
    public List<Book> FindByName(string name)
    {
        var query = $"SELECT * FROM [Book] WHERE [Category] LIKE N'%{name}%' OR [Title] LIKE N'%{name}%'";
        var command = new SqlCommand(query, _database.Connection);
        var reader = command.ExecuteReader();
        var result = new List<Book>();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }
        return result;
    }

    private Book FromReader(SqlDataReader reader)
    {
        return new Book
        {
            BookID=Convert.ToInt32(reader["BookID"].ToString()),
            ISBN=Convert.ToInt32(reader["ISBN"].ToString()),
            Title=reader["Title"].ToString(),
            Author=reader["Author"].ToString(),
            Publishyear=Convert.ToInt32(reader["publishyear"].ToString()),
            Category=reader["category"].ToString()
        };

    }
}