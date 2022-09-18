using System.Transactions;
using Library.Repositories;
using Library.Tables;

namespace Library
{
    static class TableEditor
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hospital manager");
            Console.WriteLine("which Table would you like to edit? : ");

            Console.WriteLine("1.Books" + "\n" + "2.Members" + "\n" + "3.History");
            int table = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Choose the action : "+"\n"+"1: insert"+"\n"+"2: update "+"\n"+"3: delete "+"\n"+"4: Show all the records "+"\n"+"5: Search a record by ID "+"\n"+"6:Search by string");
            int answer = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");
            if (table == 1)
            {
                var bookRepository = new BookRepository();
                var book = new Book();
                switch (answer)
                {
                    case 1:
                    {
                        Console.Write("Enter ISBN : ");
                        book.ISBN = (int) Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter Title : ");
                        book.Title = Console.ReadLine();

                        Console.WriteLine("Eneter Author : ");
                        book.Author = Console.ReadLine();

                        Console.Write("Enter Publish year : ");
                        book.Publishyear = (int) Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("Eneter Category : ");
                        book.Category = Console.ReadLine();
                        bookRepository.Insert(book);


                    }
                        break;
                    case 2:
                    {
                        Console.Write("Enter BookID : ");
                        book.BookID = (int) Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter ISBN : ");
                        book.ISBN = (int) Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter Title : ");
                        book.Title = Console.ReadLine();

                        Console.WriteLine("Eneter Author : ");
                        book.Author = Console.ReadLine();

                        Console.Write("Enter Publish year : ");
                        book.Publishyear = (int) Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("Eneter Category : ");
                        book.Category = Console.ReadLine();
                        bookRepository.Update(book);
                    }
                        break;
                    case 3:
                    {
                        Console.Write("Enter Book ID : ");
                        book.BookID = Convert.ToInt32(Console.ReadLine());
                        bookRepository.Delete(book);
                    }
                        break;
                    case 4:
                    {
                        IList<Book> allBooks;
                        allBooks = bookRepository.SelectAll();

                        foreach (var b in allBooks)
                        {
                           b.Printbook();
                        }
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Enter The ID : "+"\n");
                        int bookid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");
                        var myBook = bookRepository.GetById(bookid);
                        foreach (var b in myBook)
                        {
                            b.Printbook();
                        }
                    }
                        break;
                    case 6:
                    {
                        Console.WriteLine("Enter the name : ");
                        var myName = Console.ReadLine();
                        var findTheName = bookRepository.FindByName(myName);
                        foreach (var b in findTheName)
                        {
                            b.Printbook();
                        }

                    }
                        break;



                }

            }
            else
            {
                if (table == 2)
                {
                    var memoryRepository = new MemberRepository();
                    var member = new Member();
                    switch (answer)
                    {
                        case 1:
                        {
                            Console.Write("Enter FirstName : ");
                            member.FirstName = Console.ReadLine();

                            Console.Write("Enter LastName : ");
                            member.LastName = Console.ReadLine();

                            Console.WriteLine("Eneter Adress : ");
                            member.MemberAddress = Console.ReadLine();

                            Console.Write("Enter Phone Number : ");
                            member.PhoneNumber = (int) Convert.ToInt64(Console.ReadLine());

                            Console.WriteLine("Eneter Limit : ");
                            member.LimitBook = Convert.ToInt32(Console.ReadLine());
                            memoryRepository.InsertMember(member);

                        }
                            break;
                        case 2:
                        {
                            Console.WriteLine("Enter Member ID : ");
                            member.MemberID = (int) Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter FirstName : ");
                            member.FirstName = Console.ReadLine();

                            Console.Write("Enter LastName : ");
                            member.LastName = Console.ReadLine();

                            Console.WriteLine("Eneter Adress : ");
                            member.MemberAddress = Console.ReadLine();

                            Console.Write("Enter Phone Number : ");
                            member.PhoneNumber = (int) Convert.ToInt64(Console.ReadLine());

                            Console.WriteLine("Eneter Limit : ");
                            member.LimitBook = Convert.ToInt32(Console.ReadLine());
                            MemberRepository.UpdateMember(member);
                        }
                            break;
                        case 3:
                        {
                            Console.Write("Enter Member ID : ");
                            member.MemberID = Convert.ToInt32(Console.ReadLine());
                            memoryRepository.DeleteMember(member);
                        }
                            break;
                        case 4:
                        {
                            IList<Member> allmember;
                            allmember = memoryRepository.SelectAll();

                            foreach (var b in allmember)
                            {
                                b.Printmember();
                            }
                            break;
                        }
                        case 5:
                        {
                            Console.WriteLine("Enter The ID : "+"\n");
                            int memberid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n");
                            var myMember = memoryRepository.GetById(memberid);
                            foreach (var b in myMember)
                            {
                                b.Printmember();
                            }
                        }
                            break;
                        case 6:
                        {
                            Console.WriteLine("Enter the name : ");
                            var myName = Console.ReadLine();
                            var findTheName = memoryRepository.FindByName(myName);
                            foreach (var b in findTheName)
                            {
                                b.Printmember();
                            }

                        }
                            break;
                    }
                }
                else
                {
                    if (table == 3)
                    {
                        var historyRepository = new HistoryRepository();
                        var history = new History();
                        switch (answer)
                        {
                            case 1:
                            {
                                Console.Write("Enter BookID : ");
                                history.BookID = (int) Convert.ToInt64(Console.ReadLine());

                                Console.Write("Enter MemberID : ");
                                history.MemberID = (int) Convert.ToInt64(Console.ReadLine());

                                Console.Write("Enter LoanDate : ");
                                history.LoanDate = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Enter DueDate : ");
                                history.DueDate = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Enter ReturnDate : ");
                                history.ReturnDate = Convert.ToDateTime(Console.ReadLine());
                                historyRepository.InsertHistory(history);


                            }
                                break;
                            case 2:
                            {
                                Console.Write("Enter BookID : ");
                                history.Id = (int) Convert.ToInt64(Console.ReadLine());
                                Console.Write("Enter BookID : ");
                                history.BookID = (int) Convert.ToInt64(Console.ReadLine());

                                Console.Write("Enter MemberID : ");
                                history.MemberID = (int) Convert.ToInt64(Console.ReadLine());

                                Console.Write("Enter LoanDate : ");
                                history.LoanDate = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Enter DueDate : ");
                                history.DueDate = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Enter ReturnDate : ");
                                history.ReturnDate = Convert.ToDateTime(Console.ReadLine());
                                historyRepository.UpdateHistory(history);
                            }
                                break;
                            case 3:
                            {
                                Console.Write("Enter History ID : ");
                                history.Id = Convert.ToInt32(Console.ReadLine());
                                historyRepository.DeleteHistory(history);
                            }
                                break;
                            case 4:
                            {
                                IList<History> allhistory;
                                allhistory = historyRepository.SelectAll();

                                foreach (var b in allhistory)
                                {
                                    b.Printhistory();
                                }
                                break;
                            }
                            case 5:
                            {
                                Console.WriteLine("Enter The ID : "+"\n");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n");
                                var myhistory = historyRepository.GetById(id);
                                foreach (var b in myhistory)
                                {
                                    b.Printhistory();
                                }
                            }
                                break;
                            case 6:
                            {
                                Console.WriteLine("Enter the Date : ");
                                DateTime myName = Convert.ToDateTime(Console.ReadLine());
                                var findTheName = historyRepository.FindByDate(myName);
                                foreach (var b in findTheName)
                                {
                                    b.Printhistory();
                                }

                            }
                                break;

                        }
                    }
                }
            }

            Console.WriteLine("Press any key to quite");
            Console.Read();
        }
    }
}