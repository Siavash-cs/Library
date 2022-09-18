namespace Library.Tables;

public class History
{
    public int Id { get; set; }
    public int MemberID { get; set; }
    public int BookID { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public void Printhistory()
    {
        Console.WriteLine("================================");
        Console.WriteLine($"Id : {Id}");
        Console.WriteLine($"MemberID: {MemberID}");
        Console.WriteLine($"BookID : {BookID}");
        Console.WriteLine($"LoanDate : {LoanDate}");
        Console.WriteLine($"DueDate : {DueDate}");
        Console.WriteLine($"ReturnDate : {ReturnDate}");
        Console.WriteLine("================================");
    }
}