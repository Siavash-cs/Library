using Microsoft.Data.SqlClient;
using Library.Tables;

namespace Library;

public class DataBase
{
    private const string _StringCode =
        "Server=.;Database=Library;User ID=sa;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True";

    private SqlConnection _scode;

    public DataBase()
    {
        _scode = new SqlConnection(_StringCode);
        _scode.Open();
    }
    public SqlConnection Connection => _scode;


    ~DataBase()
    {
        _scode.Close();
    }
    
}