public class TaskLibrary
{
    public static void Main(String[] args)
    {
        Library lib = new Library();

        lib.AddBook(new Book("AAAAAAAAAAAA", "B", 1));
        lib.AddBook("BBBBBBB", "A", 1);
        lib.AddBook("CCCCCCC", "A", 2);
        lib.AddBook("AAAAAAAAAAAA", "A", 3);

        Console.WriteLine("Write author:");
        string author = Console.ReadLine();

        Console.WriteLine("Books with this author:");
        foreach (Book book in lib.FindAllByAuthor(author))
        {
            Console.WriteLine(book);
        }
    }
}

public class Book
{
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }

    public override string ToString()
    {
        return $"{Title} by {Author}, {Year}";
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

    public LinkedList<Book> FindAllByTitle(string title)
    {
        return FindWithPredicate((Book book) => book.Title.Equals(title));
    }

    public LinkedList<Book> FindAllByYear(int year)
    {
        return FindWithPredicate((Book book) => book.Year == year);
    }

    public LinkedList<Book> FindAllByAuthor(string author)
    {
        return FindWithPredicate((Book book) => book.Author.Equals(author));
    }

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
