public class TaskFourtyOne
{
    public static void Main(string[] args)
    {
        Player player = new Player();

        Deck deck = new Deck(true);

        deck.Shuffle();

        for (int i = 0; i < 20; i++)
        {
            player.Draw(deck);
        }

        player.PrintHand();
    }
}

public class Deck
{
    private const int FullDeckSize = 52;
    private static readonly int _shortDeckSize = 36;

    private static readonly int _fullDeckMinimalCardId = 0;
    private static readonly int _shortDeckMinimalCardId = FullDeckSize - _shortDeckSize;

    private Card[] _cards = null;
    private int _cardsLeft = 0;

    public class Card
    {
        public static readonly int SuitsCount = 4;
        public static readonly int MaxValue = 13;
        public static readonly int MinValue = 1;

        public static readonly int DefaultId = 0;

        private readonly string[] _valuesName = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        public byte Value { get; private set; } = 0;
        public Suits Suit { get; private set; } = Suits.Hearts;

        public Card(byte value, Suits suit)
        {
            Suit = suit;
            Value = value;
        }

        public Card(int id)
        {
            if (id >= MaxValue * SuitsCount || id < (MinValue - 1))
            {
                id = DefaultId;
                Console.Error.WriteLine("Failed to create card by id. Use id " + DefaultId);
            }

            Value = (byte) (id / SuitsCount + 1);
            Suit = (Suits) (id % SuitsCount);
        }

        public enum Suits : int
        {
            Hearts = 0,
            Spades = 1,
            Clubs = 2,
            Diamonds = 3
        }

        public override string ToString()
        {
            return _valuesName[Value - 1] + " of " + Suit.ToString();
        }
    }

    public Deck(bool useFullDeck)
    {
        _cards = new Card[useFullDeck ? FullDeckSize : _shortDeckSize];

        int minimalCardId = useFullDeck ? _fullDeckMinimalCardId : _shortDeckMinimalCardId;

        for (int i = minimalCardId; i < FullDeckSize; i++)
        {
            _cards[i - minimalCardId] = new Card(i);
        }

        _cardsLeft = _cards.Length;
    }

    public Card TakeCard()
    {
        if (_cardsLeft == 0)
        {
            return null;
        }

        _cardsLeft--;
        return _cards[_cardsLeft - 1];
    }

    public void Shuffle(int depth = FullDeckSize)
    {
        Random random = new Random();

        for (int i = 0; i < depth; i++)
        {
            int swapWithIndex = random.Next(1, _cardsLeft);
            (_cards[0], _cards[swapWithIndex]) = (_cards[swapWithIndex], _cards[0]);
        }
    }
}

public class Player
{
    LinkedList<Deck.Card> _hand = new LinkedList<Deck.Card>();

    public bool Draw(Deck deck)
    {
        Deck.Card pulledCard = deck.TakeCard();

        if (pulledCard == null)
        {
            return false;
        }

        _hand.AddLast(deck.TakeCard());
        return true;
    }

    public void TakeCard(Deck.Card card)
    {
        _hand.Remove(card);
    }

    public void PrintHand()
    {
        foreach (Deck.Card card in _hand)
        {
            Console.WriteLine(card.ToString());
        }
    }
}
