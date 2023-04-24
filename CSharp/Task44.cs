public class TaskMarket
{
    private static Random random = new Random();

    public static void Main(String[] args)
    {
        Market m = new();

        m.AddProduct(new Product(100, "A"));
        m.AddProduct(new Product(90, "B"));
        m.AddProduct(new Product(80, "C"));
        m.AddProduct(new Product(70, "D"));
        m.AddProduct(new Product(60, "E"));

        List<Customer> customers = new List<Customer>(random.Next(100));

        for (int i = 0; i < customers.Count; i++)
        {
            customers[i] = new Customer(random.Next());
        }

        foreach (Customer customer in customers)
        {
            m.Transit(customer.Buy());
        }
    }

    public static void FillCartWithRandomProducts(Customer customer, Market market)
    {
        int products = random.Next(100);

        Product[] range = market.GetRange();

        for (int i = 0; i < products; i++)
        {
            customer.ChooseRandomProduct(range);
        }
    }
}

public struct Product
{
    public readonly int Price;
    public readonly string Name;

    public Product(int price, string name)
    {
        Price = price;
        Name = name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() * 31 + Price;
    }
}

public interface ISeller
{
    public Product[] GetRange();
}

public class Market : ISeller
{
    private HashSet<Product> _range = new HashSet<Product>();
    private int _balance = 0;

    public void AddProduct(Product product)
    {
        _range.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _range.Remove(product);
    }

    public Product[] GetRange()
    {
        return _range.ToArray();
    }

    public void Buy(Product product)
    {
        _balance += product.Price;
    }

    public void Transit(int bill)
    {
        _balance += bill;
    }
}

public class Customer
{
    private LinkedList<Product> _cart = new LinkedList<Product>();
    private int _cartTotalPrice = 0;
    private int _money = 0;

    private Random _decisionSource = new Random();

    public Customer(int money)
    {
        _money = money;
    }

    public void ChooseRandomProduct(Product[] range)
    {
        AddToCart(range[_decisionSource.Next(range.Length)]);
    }

    public void AddToCart(Product product)
    {
        _cart.AddLast(product);
        _cartTotalPrice += product.Price;
    }

    public void RemoveFromCart(Product product)
    {
        if (_cart.Remove(product))
        {
            _cartTotalPrice -= product.Price;
        }
    }

    public int Buy()
    {
        while (_cartTotalPrice > _money)
        {
            RemoveFromCart(_decisionSource.Next(_cart.Count));
        }

        _cart.Clear();
        _money -= _cartTotalPrice;
        return _cartTotalPrice;
    }

    private void RemoveFromCart(int index)
    {
        RemoveFromCart(_cart.ElementAt(index));
    }
}

