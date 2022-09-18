using Library.Tables;
using Microsoft.Data.SqlClient;

namespace Library.Repositories;

public class MemberRepository
{
    private static DataBase _database;

    public MemberRepository()
    {
        _database = new DataBase();
    }


    public void InsertMember(Member member)
    {
        const string insertCmd =
            @"INSERT Into [Member] ([FirstName],[LastName],[MemberAddress],[PhoneNumber],[LimitBook]) VALUES (@FirstName,@LastName,@Adress_,@PhoneNumber,@Limit_)";
        var command = new SqlCommand(insertCmd, _database.Connection);
        command.Parameters.AddWithValue("FirstName", member.FirstName);
        command.Parameters.AddWithValue("LastName", member.LastName);
        command.Parameters.AddWithValue("MemberAddress", member.MemberAddress);
        command.Parameters.AddWithValue("PhoneNumber", member.PhoneNumber);
        command.Parameters.AddWithValue("LimitBook", member.LimitBook);
        command.ExecuteNonQuery();
    }

    public static void UpdateMember(Member member)
    {
        var command = new SqlCommand(
            "UPDATE [Member] SET [FirstName] =@FirstName ,[LastName]=@LastName,[MemberAddress]=@MemberAddress ,[PhoneNumber]=@PhoneNumber WHERE [MemberID] = @MemberID", 
            _database.Connection);
        command.Parameters.AddWithValue("MemberID", member.MemberID);
        command.Parameters.AddWithValue("FirstName", member.FirstName);
        command.Parameters.AddWithValue("LastName", member.LastName);
        command.Parameters.AddWithValue("MemberAddress", member.MemberAddress);
        command.Parameters.AddWithValue("PhoneNumber", member.PhoneNumber);
        command.Parameters.AddWithValue("LimitBook", member.LimitBook);
        command.ExecuteNonQuery();
    }

    public void DeleteMember(Member member)
    {
        var command = new SqlCommand("DELETE FROM Member WHERE MemberID=@MemberID", _database.Connection);
        command.Parameters.AddWithValue("MemberID", member.MemberID);
        command.ExecuteNonQuery();
    }

    public IList<Member> SelectAll()
    {
        var result = new List<Member>();
        var command = new SqlCommand("SELECT * FROM [Member]",_database.Connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }
        return result;
    }

    public List<Member> GetById(int id)
    {
        var members = new List<Member>();
        var command = new SqlCommand("SELECT * FROM [Member] WHERE [MemberID] = @MemberID",_database.Connection);
        command.Parameters.AddWithValue("MemberID", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            members.Add(FromReader(reader)) ;
        }

        return members;
    }
    
    public List<Member> FindByName(string name)
    {
        var query = $"SELECT * FROM [Member] WHERE [FirstName] LIKE N'%{name}%' OR [MemberAddress] LIKE N'%{name}%'";
        var command = new SqlCommand(query, _database.Connection);
        var reader = command.ExecuteReader();
        var result = new List<Member>();
        while (reader.Read())
        {
            result.Add(FromReader(reader));
        }
        return result;
    }

    private Member FromReader(SqlDataReader reader)
    {
        return new Member
        {
            MemberID=Convert.ToInt32(reader["MemberID"].ToString()),
            FirstName =(reader["FirstName"].ToString()),
            LastName = reader["LastName"].ToString(),
            MemberAddress = reader["MemberAddress"].ToString(),
            PhoneNumber = Convert.ToInt64(reader["PhoneNumber"].ToString()),
            LimitBook = Convert.ToInt32(reader["LimitBook"].ToString())
        };

    }
}