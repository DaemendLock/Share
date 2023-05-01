public class TaskFourtyOne
{
    public static void Main(string[] args)
    {
        const string PassCommand = "pass";
        const string ShuffleCommand = "shuffle";
        const string PrintCommand = "print";

        int maxDrawCrads = 20;

        Player player = new Player();

        Deck deck = new PlayingDeck(true);

        for (int i = 0; i < maxDrawCrads; i++)
        {
            Console.WriteLine($"Write {ShuffleCommand} to shuffle deck, {PrintCommand} to pring cards in your hand or {PassCommand}");

            switch (Console.ReadLine())
            {
                case ShuffleCommand:
                    deck.Shuffle();
                    break;

                case PrintCommand:
                    player.PrintHand();
                    break;

                case PassCommand:
                    break;

                default:
                    Console.Error.WriteLine("Can't read command");
                    continue;
            }

            Card card = deck.GiveCard();

            if (card == null)
            {
                Console.Error.WriteLine("Can't draw card - deck is empity");
                return;
            }

            player.PickupCard(card);
            Console.WriteLine("Picked up " + card);
        }

        player.PrintHand();
    }
}

public class Deck
{
    private Card[] _cards = null;

    private int _cardsLeft = 0;

    public Deck(int size)
    {
        _cards = new Card[size];
    }

    public void Put(Card card)
    {
        if (card == null)
            return;

        _cards[_cardsLeft++] = card;
    }

    public Card GiveCard()
    {
        if (_cardsLeft == 0)
        {
            Console.Error.WriteLine("Failed to draw card - deck is empity");
            return null;
        }

        Card result = _cards[--_cardsLeft];
        _cards[_cardsLeft] = null;

        return result;
    }

    public void Shuffle()
    {
        Random random = new Random();

        for (int i = 0; i < _cardsLeft - 1; i++)
        {
            int swapWithIndex = random.Next(i);
            (_cards[i], _cards[swapWithIndex]) = (_cards[swapWithIndex], _cards[i]);
        }
    }
}

public class PlayingDeck : Deck
{
    private const int FullDeckSize = 52;
    private const int ShortDeckSize = 36;
    private const int FullDeckMinimalCardId = 0;
    private const int ShortDeckMinimalCardId = FullDeckSize - ShortDeckSize;

    public PlayingDeck(bool useFullDeck) : base(useFullDeck ? FullDeckSize : ShortDeckSize)
    {
        int minimalCardId = useFullDeck ? FullDeckMinimalCardId : ShortDeckMinimalCardId;

        for (int i = minimalCardId; i < FullDeckSize; i++)
        {
            Put(new PlayingCard(i));
        }
    }
}

public class Card
{
    public Card(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }

    public override bool Equals(object obj)
    {
        return obj is Card card && card.Id == Id;
    }
}

public class PlayingCard : Card
{
    private const int DefaultId = 0;

    public static readonly string[] Values = {
        "Ace", "Two", "Three",
    "Four", "Five", "Six",
     "Seven", "Eight", "Nine",
     "Ten", "Jack", "Queen", "King"};

    public static readonly string[] Suits = { "Hearts", "Spades", "Clubs", "Diamonds" };

    public PlayingCard(int id) : base(id)
    {
        if (id >= (Values.Length * Suits.Length) || id < 0)
        {
            Console.WriteLine("Can't create card with given id. Using default instead.");
            id = DefaultId;
        }

        Value = id % Values.Length;
        Suit = id / Values.Length;
    }

    public int Value { get; private set; }
    public int Suit { get; private set; }

    public override string ToString()
    {
        return Values[Value] + " of " + Suits[Suit];
    }

    public override bool Equals(object obj)
    {
        return obj is PlayingCard card && card.Value == Value && card.Suit == Suit;
    }
}

public class Player
{
    private LinkedList<Card> _hand = new();

    public void PickupCard(Card card)
    {
        if (card == null)
        {
            Console.Error.WriteLine("Can't pick up non-existing card");
            return;
        }

        _hand.AddLast(card);
    }

    public void DropCard(Card card)
    {
        _hand.Remove(card);
    }

    public void PrintHand()
    {
        if (_hand.Count == 0)
        {
            Console.WriteLine("Hand is empity");
        }

        foreach (Card card in _hand)
        {
            Console.WriteLine(card.ToString());
        }
    }
}
