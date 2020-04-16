using System;
using System.Collections.Generic;
using System.Linq;

class Pocker
{
    public static void Run()
    {
        var hand1 = new Hand(new string[5] { "Ta", "Ja", "Qa", "Ka", "Aa" });
        var hand2 = new Hand(new string[5] { "2a", "2b", "2c", "3d", "3x" });

        int winner = Hand.Compare(hand1, hand2);

        Console.WriteLine("Player {0} wins", winner);

    }
}

class Hand
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public enum Ranks
    {
        HighCard,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    };

    public Hand(string[] cards)
    {
        foreach (var card in cards)
        {
            Cards.Add(new Card(card));
        }
        Cards.Sort();
    }

    public static int Compare(Hand hand1, Hand hand2)
    {
        if (hand1.Rank > hand2.Rank)
            return 1;

        if (hand2.Rank > hand1.Rank)
            return 2;

        hand1.PockerSort();
        hand2.PockerSort();

        for (int i = 0; i < hand1.Cards.Count; i++)
        {
            if (hand1.Cards[i] > hand2.Cards[i])
                return 1;
            if (hand1.Cards[i] < hand2.Cards[i])
                return 2;
        }
        return 2;
    }
    private Ranks? _rank = null;
    public Ranks Rank
    {
        get
        {
            if (_rank != null)
                return _rank.Value;

            if (IsRoyalFlush)
                _rank = Ranks.RoyalFlush;

            else if (IsStraightFlush)
                _rank = Ranks.StraightFlush;

            else if (IsFourOfAKind)
                _rank = Ranks.FourOfAKind;

            else if (IsFullHouse)
                _rank = Ranks.FullHouse;

            else if (IsFlush)
                _rank = Ranks.Flush;

            else if (IsStraight)
                _rank = Ranks.Straight;

            else if (IsThreeOfAKind)
                _rank = Ranks.ThreeOfAKind;

            else if (IsTwoPairs)
                _rank = Ranks.TwoPairs;

            else if (IsPair)
                _rank = Ranks.Pair;

            else
                _rank = Ranks.HighCard;

            return _rank.Value;

        }
    }

    public bool IsPair
    {
        get
        {
            return Kinds >= 2;
        }
    }

    public bool IsTwoPairs
    {
        get
        {
            int pairs = 0;
            for (int i = 0; i < Cards.Count - 1; i++)
            {
                if (Cards[i].Value == Cards[i + 1].Value)
                {
                    pairs++;
                    i++;
                }
            }
            return pairs == 2;
        }
    }

    public bool IsThreeOfAKind
    {
        get
        {
            return Kinds >= 3;
        }
    }

    public bool IsStraight
    {
        get
        {
            for (int i = 0; i < Cards.Count - 1; i++)
            {
                if (Cards[i].Value != Cards[i + 1].Value - 1)
                    return false;
            }
            return true;
        }
    }

    public bool IsFlush
    {
        get
        {
            for (int i = 0; i < Cards.Count - 1; i++)
            {
                if (Cards[i].Suit != Cards[i + 1].Suit)
                    return false;
            }
            return true;
        }
    }

    public bool IsFullHouse
    {
        get
        {
            return Cards.Select(x => x.Value).Distinct().Count() == 2;
        }
    }

    public bool IsFourOfAKind
    {
        get
        {
            return Kinds == 4;
        }
    }

    public bool IsStraightFlush
    {
        get
        {
            return IsStraight && IsFlush;
        }
    }

    public bool IsRoyalFlush
    {
        get
        {
            return IsFlush && IsStraight && Cards[0].Value == 10;
        }
    }

    private void PockerSort()
    {
        switch (Rank)
        {
            case Ranks.RoyalFlush:
            case Ranks.StraightFlush:
            case Ranks.Flush:
            case Ranks.Straight:
            case Ranks.HighCard:
                Cards.Sort((a, b) => b.CompareTo(a));
                break;
            case Ranks.FourOfAKind:
            case Ranks.FullHouse:
            case Ranks.ThreeOfAKind:
            case Ranks.TwoPairs:
            case Ranks.Pair:
                SortByFrequency();
                break;
        }
    }

    private void SortByFrequency()
    {
        Cards = Cards
            .GroupBy(x => x.Value)
            .OrderByDescending(x => x.Count())
            .ThenByDescending(x => x.Key)
            .SelectMany(x => x)
            .ToList();
    }

    private int _kinds = -1;
    private int Kinds
    {
        get
        {
            if (_kinds > -1)
                return _kinds;

            int max = 0;
            _kinds = 0;
            for (int i = 0; i < Cards.Count - 1; i++)
            {
                if (Cards[i].Value == Cards[i + 1].Value)
                {
                    _kinds++;
                    if (_kinds > max)
                        max = _kinds;
                }
                else
                    _kinds = 0;
            }
            _kinds = max;
            return _kinds;
        }
    }

}

class Card : IComparable<Card>
{
    public char Suit { get; set; }
    public int Value { get; set; }
    public Card(string card)
    {
        switch (card[0])
        {
            case 'T':
                Value = 10;
                break;

            case 'J':
                Value = 11;
                break;

            case 'Q':
                Value = 12;
                break;

            case 'K':
                Value = 13;
                break;

            case 'A':
                Value = 14;
                break;

            default:
                Value = card[0] - '0';
                break;
        }

        Suit = Char.ToLower(card[1]);
    }
    public static bool operator >(Card card1, Card card2)
    {
        return card1.Value > card2.Value;
    }
    public static bool operator <(Card card1, Card card2)
    {
        return card1.Value < card2.Value;
    }

    public int CompareTo(Card other)
    {
        return Value.CompareTo(other.Value);
    }
}
