namespace Library.Tables;

public class Book
{
    public int BookID { get; set; }
    
    public long ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Publishyear { get; set; }
    public string Category { get; set; }



    public void Printbook()
    {
        Console.WriteLine("================================");
        Console.WriteLine($"BookID: {BookID}");
        Console.WriteLine($"ISBN : {ISBN}");
        Console.WriteLine($"Title : {Title}");
        Console.WriteLine($"Author : {Author}");
        Console.WriteLine($"publishyear : {Publishyear}");
        Console.WriteLine($"category : {Category}");
        Console.WriteLine("================================");
    }
}