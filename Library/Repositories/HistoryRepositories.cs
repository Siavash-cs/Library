using System.Runtime.InteropServices.ComTypes;
using Library.Tables;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Library.Repositories;

public class HistoryRepository
{
    private static DataBase _database;

    public HistoryRepository()
    {
        _database = new();
    }


    public void InsertHistory(History history)
    {
        const string insertCmd =
            @"INSERT INTO [History]([BookID],[MemberID],[LoanDate],[DueDate],[ReturnDate]) VALUES (@BookID,@MemberID,@LoanDate,@DueDate,@ReturnDate)" ;
        var command = new SqlCommand(insertCmd, _database.Connection);
        command.Parameters.AddWithValue("BookID",history.BookID);
        command.Parameters.AddWithValue("MemberID",history.MemberID);
        command.Parameters.AddWithValue("LoanDate",history.LoanDate);
        command.Parameters.AddWithValue("DueDate", history.DueDate);
        command.Parameters.AddWithValue("ReturnDate", history.ReturnDate);
        command.ExecuteNonQuery();
    }

    public void UpdateHistory(History history)
    {
        var command =
            new SqlCommand(
                "UPDATE History SET LoanDate=@LoanDate ,DueDate=@DueDate,ReturnDate=@ReturnDate WHERE Id=@Id",_database.Connection);
        command.Parameters.AddWithValue("BookID",history.BookID);
        command.Parameters.AddWithValue("MemberID",history.MemberID);
        command.Parameters.AddWithValue("LoanDate",history.LoanDate);
        command.Parameters.AddWithValue("DueDate", history.DueDate);
        command.Parameters.AddWithValue("ReturnDate", history.ReturnDate);
        command.ExecuteNonQuery();
    }

    public void DeleteHistory(History history)
    {
        var command = new SqlCommand("delete from History where Id=@BookId", _database.Connection);
        command.Parameters.AddWithValue("Id", history.Id);
        command.ExecuteNonQuery();
    }

    public IList<History> SelectAll()
    {
        var result = new List<History>();
        var command = new SqlCommand("SELECT * FROM [History]",_database.Connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }

        return result;
    }

    public List<History> GetById(int id)
    {
        var history = new List<History>();
        var command = new SqlCommand("SELECT * FROM [History] WHERE [Id] = @Id", _database.Connection);
        command.Parameters.AddWithValue("Id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            history.Add(FromReader(reader));
        }

        return history;
    }
    public List<History> FindByDate(DateTime date)
    {
        var result = new List<History>();
        var query = new SqlCommand("SELECT * FROM [History] WHERE [LoanDate] = @LoanDate ",_database.Connection);
        query.Parameters.AddWithValue("Id", date);
        var reader = query.ExecuteReader();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }
        return result;
    }

    private static History FromReader(SqlDataReader reader)
        {
            return new History
            {
                Id = Convert.ToInt32(reader["Id"].ToString()),
                MemberID = Convert.ToInt32(reader["MemberID"].ToString()),
                BookID = Convert.ToInt32(reader["BookID"].ToString()),
                LoanDate = Convert.ToDateTime(reader["LoanDate"].ToString()),
                DueDate = Convert.ToDateTime(reader["DueDate"].ToString()),
                ReturnDate = Convert.ToDateTime(reader["ReturnDate"].ToString())
            };

        }
    }


