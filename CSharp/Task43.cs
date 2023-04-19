public class TaskTrade
{
    public static void Main(String[] args)
    {
        Customer customer = new Customer();
        Trader trader = new Trader();
        trader.Give(new Item("Rusty sword", "Old rusted sword of your dad."));

        Console.WriteLine("Trader has:");
        trader.ShowItems();
        Console.WriteLine("Customer has:");
        customer.ShowItems();

        Console.WriteLine("Trying get your father's sword");
        customer.TryBuy("Rusty sword", trader);

        Console.WriteLine("Trader has:");
        trader.ShowItems();
        Console.WriteLine("Customer has:");
        customer.ShowItems();
    }
}

public class Item
{
    public Item(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return Title + " - " + Description;
    }

    public override bool Equals(object obj)
    {
        return obj is Item && ((Item) obj).Title.Equals(Title);
    }
}

public abstract class ItemHolder
{
    private LinkedList<Item> _items = new LinkedList<Item>();

    public void ShowItems()
    {
        foreach (Item item in _items)
        {
            Console.WriteLine(item);
        }
    }

    public void Give(Item item)
    {
        _items.AddLast(item);
    }

    public Item TakeItem(string title)
    {
        Item result = Find(title);

        _items.Remove(result);
        return result;
    }

    public Item Find(string title)
    {
        return _items.First((Item item) => item.Title.Equals(title));
    }
}

public class Customer : ItemHolder
{
    public bool TryBuy(string title, Trader trader)
    {
        Item item = trader.TakeItem(title);
        if (item != null)
        {
            Give(item);
        }

        return item != null;
    }
}

public class Trader : ItemHolder
{

}
