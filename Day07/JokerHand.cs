namespace Day07;

public class JokerHand : IComparable<JokerHand>
{
    public string Cards { get; }

    public string SortedCards => new(Cards.OrderByDescending(CardIndex).Select(c => c).ToArray());
    public int Bid { get; }
    private HandType type;

    public JokerHand(string cards, int bid)
    {
        Cards = cards;
        Bid = bid;
        DetermineHandType();
    }

    public HandType DetermineHandType()
    {
        var counts = new Dictionary<char, int>();
        foreach (char card in Cards)
        {
            if (!counts.ContainsKey(card)) counts[card] = 0;
            counts[card]++;
        }

        if (counts.ContainsKey('J') && counts.Count > 1)
        {
            var value = counts['J'];
            counts.Remove('J');

            var highest = counts.OrderByDescending(c => c.Value).ThenByDescending(c => CardIndex(c.Key)).First();
            value += highest.Value;
            
            counts.Remove(highest.Key);
            counts.Add(highest.Key, value);
        }

        var groups = counts.GroupBy(kv => kv.Value).ToDictionary(g => g.Key, g => g.Select(kv => kv.Key).ToList());
        groups = groups.OrderByDescending(g => g.Key).ThenByDescending(g => g.Value.Max(c => CardIndex(c))).ToDictionary(g => g.Key, g => g.Value);

        if (groups.ContainsKey(5)) type = HandType.FiveOfAKind;
        else if (groups.ContainsKey(4)) type = HandType.FourOfAKind;
        else if (groups.ContainsKey(3) && groups.ContainsKey(2)) type = HandType.FullHouse;
        else if (groups.ContainsKey(3)) type = HandType.ThreeOfAKind;
        else if (groups.ContainsKey(2) && groups[2].Count == 2) type = HandType.TwoPair;
        else if (groups.ContainsKey(2)) type = HandType.OnePair;
        else type = HandType.HighCard;

        return type;
    }

    private static int CardIndex(char card)
    {
        return "J23456789TQKA".IndexOf(card);
    }

    public int CompareTo(JokerHand other)
    {
        if (type != other.type) return type.CompareTo(other.type);
        for (int i = 0; i < Cards.Length; i++)
        {
            var index = CardIndex(Cards[i]);
            var otherIndex = CardIndex(other.Cards[i]);
            int diff = index - otherIndex;
            if (diff != 0)
            {
                return diff;
            }
        }
        return 0;
    }
}