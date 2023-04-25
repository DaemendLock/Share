public class TaskFourtyOne
{
    public static void Main(string[] args)
    {
        const string PassCommand = "pass";
        const string ShuffleCommand = "suffle";
        const string PrintCommand = "print";

        int drawCards = 20;

        Player player = new Player();

        Deck deck = new PlayingDeck(true);

        string userInput;

        for (int i = 0; i < drawCards; i++)
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

    private uint _cardsLeft = 0;

    public Deck(uint size)
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
            Console.WriteLine("Failed to draw card - deck is empity");
            return null;
        }

        return _cards[--_cardsLeft];
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
    private const uint FullDeckSize = 52;
    private const uint ShortDeckSize = 36;
    private const uint FullDeckMinimalCardId = 0;
    private const uint ShortDeckMinimalCardId = FullDeckSize - ShortDeckSize;

    public PlayingDeck(bool useFullDeck) : base(useFullDeck ? FullDeckSize : ShortDeckSize)
    {
        uint minimalCardId = useFullDeck ? FullDeckMinimalCardId : ShortDeckMinimalCardId;

        for (uint i = minimalCardId; i < FullDeckSize; i++)
        {
            Put(new PlayingCard(i));
        }
    }
}

public class Card
{
    public Card(uint id)
    {
        Id = id;
    }

    public uint Id { get; private set; }

    public override bool Equals(object obj)
    {
        return obj is Card card && card.Id == Id;
    }
}

public class PlayingCard : Card
{
    private const uint DefaultId = 0;

    public enum Values : uint
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Count,
    }

    public enum Suits : uint
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds,
        Count
    }

    public PlayingCard(uint id) : base(id)
    {
        if (id >= ((uint) Values.Count * (uint) Suits.Count))
        {
            Console.WriteLine("Can't create card with given id. Using default instead.");
            id = DefaultId;
        }

        Value = (Values) (id % (uint) Values.Count + 1);
        Suit = (Suits) (id / (uint) Values.Count);
    }

    public Values Value { get; private set; }
    public Suits Suit { get; private set; }

    public override string ToString()
    {
        return Value.ToString() + " of " + Suit.ToString();
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
