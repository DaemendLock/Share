public class TaskMarket
{
    private static Random _random = new Random();

    public static void Main(String[] args)
    {
        int maxProduct = 100;
        int maxMoney = 100;

        Market market = new();

        List<Customer> customers = new List<Customer>(_random.Next(maxMoney));

        for (int i = 0; i < customers.Count; i++)
        {
            customers[i] = new Customer(_random.Next());
            int productsToBuy = _random.Next(maxProduct);

            Product[] range = market.GetRange();

            for (int j = 0; j < productsToBuy; j++)
            {
                customers[i].ChooseRandomProduct(range);
            }
        }

        foreach (Customer customer in customers)
        {
            market.Transit(customer.Buy());
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
        int hashCoefficient = 31;
        return Name.GetHashCode() * hashCoefficient + Price;
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
    }

    public void RemoveFromCart(Product product)
    {
        _cart.Remove(product);
    }

    public int Buy()
    {
        while (CanPay() == false)
        {
            RemoveFromCart(_decisionSource.Next(_cart.Count));
        }

        int cost = CalculateCartCost();

        _money -= cost;
        return cost;
    }

    public int CalculateCartCost()
    {
        int cost = 0;

        foreach (Product product in _cart)
        {
            cost += product.Price;
        }

        return CalculateCartCost();
    }

    public bool CanPay() => CalculateCartCost() <= _money;

    private void RemoveFromCart(int index)
    {
        RemoveFromCart(_cart.ElementAt(index));
    }
}
