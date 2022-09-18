namespace Library.Tables;

public class Member
{
    public int MemberID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MemberAddress { get; set; }
    public long PhoneNumber { get; set; }
    public int LimitBook { get; set; }
    public void Printmember()
    {
        Console.WriteLine("================================");
        Console.WriteLine($"MemberID: {MemberID}");
        Console.WriteLine($"FirstName : {FirstName}");
        Console.WriteLine($"LastName : {LastName}");
        Console.WriteLine($"MemberAddress : {MemberAddress}");
        Console.WriteLine($"PhoneNumber : {PhoneNumber}");
        Console.WriteLine($"LimitBook : {LimitBook}");
        Console.WriteLine("================================");
    }
}

   