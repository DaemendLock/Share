public class TaskLibrary
{
    public static void Main(String[] args)
    {
        const string ExitCommand = "stop";
        const string AddBookCommand = "add";
        const string FindCommnad = "find";
        const string ListCommand = "list";

        Library library = new Library();

        Librarian librarian = new Librarian(library);

        string userInput;

        do
        {
            Console.WriteLine("Write command: " + AddBookCommand + " - add book, " + FindCommnad + " - find book, " + ListCommand + " - list all books, " + ExitCommand + " - leave library.");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case AddBookCommand:
                    librarian.AddBook();
                    break;

                case FindCommnad:
                    librarian.FindBooks();
                    break;

                case ListCommand:
                    librarian.ListBooks();
                    break;

                case ExitCommand:
                    continue;

                default:
                    Console.Error.WriteLine("Can't read this command");
                    continue;
            }
        } while (ExitCommand.Equals(userInput) == false);
    }
}

public class Librarian
{
    private Library _library = null;

    public Librarian(Library library)
    {
        _library = library;
    }

    public void AddBook()
    {
        string title = InputReader.ReadResponse("Write title");
        string author = InputReader.ReadResponse("Write author");
        int year = InputReader.ForceParseInt("Write year");

        _library.AddBook(title, author, year);
    }

    public void FindBooks()
    {
        const string AuthorCommand = "author";
        const string TitleCommand = "title";
        const string YearCommand = "year";

        string findMode = InputReader.ReadResponse($"Write search option: {AuthorCommand}, {TitleCommand}, {YearCommand}");

        IEnumerable<Book> found;

        switch (findMode)
        {
            case AuthorCommand:
                found = _library.FindAllByAuthor(InputReader.ReadResponse("Write author for lookup"));
                break;

            case TitleCommand:
                found = _library.FindAllByTitle(InputReader.ReadResponse("Write title for lookup"));
                break;

            case YearCommand:
                found = _library.FindAllByYear(InputReader.ForceParseInt("Write year for lookup"));
                break;

            default:
                Console.Error.WriteLine("Failed to read search option");
                return;
        }

        ListBooks(found);
    }

    public void ListBooks(IEnumerable<Book>? books = null)
    {
        books ??= _library.GetBooks();

        if (books.Count() == 0)
        {
            Console.WriteLine("No books found");
            return;
        }

        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
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
        return ($"{Title} by {Author}, {Math.Abs(Year)} {(Year >= 0 ? "AD" : "BC")}.");
    }

    public override bool Equals(object? obj)
    {
        return obj is Book book && book.Title.Equals(Title) && book.Year == Year && book.Author.Equals(Author);
    }

    public override int GetHashCode()
    {
        int hashCoefficient = 31;
        return (Title.GetHashCode() * hashCoefficient + Author.GetHashCode()) * hashCoefficient + Year.GetHashCode();
    }
}

public class Library
{
    private LinkedList<Book> _books = new LinkedList<Book>();

    public void AddBook(string title, string author, int year) =>
        AddBook(new Book(title, author, year));

    public void AddBook(Book book) =>
        _books.AddLast(book);

    public void RemoveBook(Book book) =>
        _books.Remove(book);


    public Book[] GetBooks() =>
        _books.ToArray();

    public LinkedList<Book> FindAllByTitle(string title) =>
        FindWithPredicate((Book book) => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));


    public LinkedList<Book> FindAllByYear(int year) =>
        FindWithPredicate((Book book) => book.Year == year);


    public LinkedList<Book> FindAllByAuthor(string author) =>
        FindWithPredicate((Book book) => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));


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

public static class InputReader
{
    public static int ForceParseInt(string message = "Write number")
    {
        Console.WriteLine(message);

        int result;

        while (int.TryParse(Console.ReadLine(), out result) == false)
        {
            Console.Error.WriteLine("Can't read year. Write again.");
        }

        return result;
    }

    public static string ReadResponse(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine() ?? "";
    }
}
