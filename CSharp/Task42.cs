public class TaskLibrary
{
    public static void Main(String[] args)
    {
        const string ExitCommand = "stop";
        const string NextBookCommand = "next";

        Library library = new Library();

        string userInput = "";

        do
        {
            Console.WriteLine("Write "+ NextBookCommand+" to add book or " + ExitCommand + " to stop adding");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case NextBookCommand:
                    AddBook(library);
                    break;
                case ExitCommand:
                    continue;
                default:
                    Console.Error.WriteLine("Can't read this command");
                    continue;
            }
        } while (ExitCommand.Equals(userInput) == false);

        Console.WriteLine("Write author to find books:");
        string author = Console.ReadLine();

        Console.WriteLine("Books with this author:");

        foreach (Book book in library.FindAllByAuthor(author))
        {
            Console.WriteLine(book);
        }
    }

    public static void AddBook(Library library)
    {
        Console.WriteLine("Write title");
        string title = Console.ReadLine();
        Console.WriteLine("Write author");
        string author = Console.ReadLine();
        Console.WriteLine("Write year");
        int year = ForceParseInt();

        library.AddBook(title, author, year);
    }

    public static int ForceParseInt()
    {   
        int result;

        while (int.TryParse(Console.ReadLine(), out result) == false)
        {
            Console.Error.WriteLine("Can't read year. Write again.");
        }

        return result;
    }
}

public class Book
{
    public readonly string Title;
    public readonly string Author;
    public readonly int Year;

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, {Year}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Book book && book.Title.Equals(Title) && book.Year == Year && book.Author.Equals(Author);
    }

    public override int GetHashCode()
    {
        return (Title.GetHashCode() * 31 + Author.GetHashCode()) * 31 + Year.GetHashCode();
    }
}

public class Library
{
    private LinkedList<Book> _books = new LinkedList<Book>();

    public void AddBook(string title, string author, int year)
    {
        AddBook(new Book(title, author, year));
    }

    public void AddBook(Book book)
    {
        _books.AddLast(book);
    }

    public void RemoveBook(Book book)
    {
        _books.Remove(book);
    }

    public LinkedList<Book> FindAllByTitle(string title) =>
        FindWithPredicate((Book book) => book.Title.Equals(title));

    public LinkedList<Book> FindAllByYear(int year) =>
        FindWithPredicate((Book book) => book.Year == year);


    public LinkedList<Book> FindAllByAuthor(string author) =>
        FindWithPredicate((Book book) => book.Author.Equals(author));


    private LinkedList<Book> FindWithPredicate(Predicate<Book> func)
    {
        LinkedList<Book> result = new LinkedList<Book>();

        foreach (Book book in _books)
        {
            if (func.Invoke(book))
            {
                result.AddLast(book);
            }
        }

        return result;
    }
}
