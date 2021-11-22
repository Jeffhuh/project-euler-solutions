using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p054
    {
        static Dictionary<char, int> cardValue = new Dictionary<char, int>()
        {
            ['2'] = 2, ['3'] = 3, ['4'] = 4, ['5'] = 5, ['6'] = 6, ['7'] = 7, ['8'] = 8, ['9'] = 9, ['T'] = 10, ['J'] = 11, ['Q'] = 12, ['K'] = 13, ['A'] = 14
        }; 
        public static void Solution()
        {
            // very very very bad brute force solution
            try
            {
                using (StreamReader sr = new StreamReader("../../../Files/p054.txt"))
                {
                    int count = 0;
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string s1 = line.Substring(0,14);
                        string s2 = line.Substring(15,14);
                        string[] p1 = s1.Split(" ");
                        string[] p2 = s2.Split(" ");
                        Order(p1);
                        Order(p2);
                        if (RoyalFlush(p1))
                        {
                            count++;
                            continue;
                        }
                        if (RoyalFlush(p2)) continue;

                        if (StraightFlush(p1))
                        {
                            if (StraightFlush(p2))
                            {
                                if (cardValue[p1[0][0]] > cardValue[p2[0][0]])
                                {
                                    count++;
                                    continue;
                                }
                                else continue;
                            }
                            count++;
                            continue;
                        }
                        else if (StraightFlush(p2)) continue;
                        
                        if (FourOfAKind(p1))
                        {
                            if (FourOfAKind(p2))
                            {
                                char c1 = p1[0][0] == p1[1][0] ? p1[0][0] : p1[0][0] == p1[3][0] ? p1[0][0] : p1[2][0];
                                char c2 = p2[0][0] == p2[1][0] ? p2[0][0] : p2[0][0] == p2[3][0] ? p2[0][0] : p2[2][0];
                                if (cardValue[c1] > cardValue[c2])
                                {
                                    count++; Console.WriteLine(String.Join("", p1) + "  ::  " + String.Join("", p2));
                                    continue;
                                } else if (cardValue[c2] == cardValue[c1])
                                {
                                    char c11 = '2';
                                    for (int i = 0; i < p1.Length; i++)
                                    {
                                        if (c1 != p1[i][0])
                                        {
                                            c11 = p1[i][0];
                                            break;
                                        }
                                    }
                                    char c22 = '2';
                                    for (int i = 0; i < p2.Length; i++)
                                    {
                                        if (c2 != p2[i][0])
                                        {
                                            c22 = p2[i][0];
                                            break;
                                        }
                                    }
                                    if (cardValue[c11] > cardValue[c22])
                                    {
                                        count++; Console.WriteLine(String.Join("", p1) + "  ::  " + String.Join("", p2));
                                        break;
                                    }
                                }
                                else continue;
                            }
                            count++; Console.WriteLine(String.Join("", p1) + "  ::  " + String.Join("", p2));
                            continue;
                        }
                        else if (FourOfAKind(p2)) continue;

                        if (FullHouse(p1))
                        {
                            if (FullHouse(p2))
                            {
                                char pp1;
                                char tp1;
                                if (p1[0][0] == p1[1][0] && p1[2][0] == p1[0][0])
                                {
                                    pp1 = p1[5][0];
                                    tp1 = p1[0][0];
                                }
                                else
                                {
                                    tp1 = p1[5][0];
                                    pp1 = p1[0][0];
                                }

                                char pp2;
                                char tp2;
                                if (p2[0][0] == p2[1][0] && p2[2][0] == p2[0][0])
                                {
                                    pp2 = p2[5][0];
                                    tp2 = p2[0][0];
                                }
                                else
                                {
                                    tp2 = p2[5][0];
                                    pp2 = p2[0][0];
                                }
                                if (cardValue[tp1] > cardValue[tp2])
                                {
                                    count++;
                                    continue;
                                } else if (cardValue[tp1] == cardValue[tp2])
                                {
                                    if (cardValue[pp1] > cardValue[pp2])
                                    {
                                        count++;
                                    }
                                    continue;
                                }
                            }
                            count++;
                            continue;
                        }
                        else if (FullHouse(p2)) continue;

                        if (Flush(p1))
                        {
                            if (Flush(p2))
                            {
                                if (cardValue[p1[0][0]] > cardValue[p2[0][0]])
                                {
                                    count++;
                                }
                                continue;
                            }
                            count++;
                            continue;
                        }
                        else if (Flush(p2)) continue;

                        if (Straight(p1))
                        {
                            if (Straight(p2))
                            {
                                if (cardValue[p1[0][0]] > cardValue[p2[0][0]])
                                {
                                    count++;
                                }
                                continue;
                            }
                            count++;
                            continue;
                        }
                        else if (Straight(p2)) continue;

                        if (ThreeOfAKind(p1))
                        {
                            if (ThreeOfAKind(p2))
                            {
                                char tp1 = p1[2][0];
                                char tp2 = p2[2][0];
                                if (cardValue[tp1] > cardValue[tp2])
                                {
                                    count++;
                                    continue;
                                } else if (cardValue[tp2] == cardValue[tp1])
                                {
                                    char highCard11 = '2';
                                    char highCard12 = '2';
                                    for (int i = 0; i < p1.Length; i++)
                                    {
                                        if (tp1 == p1[i][0]) continue;
                                        if (cardValue[highCard11] < cardValue[p1[i][0]])
                                        {
                                            highCard12 = highCard11;
                                            highCard11 = p1[i][0];
                                        }
                                    }

                                    char highCard21 = '2';
                                    char highCard22 = '2';
                                    for (int i = 0; i < p2.Length; i++)
                                    {
                                        if (tp2 == p2[i][0]) continue;
                                        if (cardValue[highCard21] < cardValue[p2[i][0]])
                                        {
                                            highCard22 = highCard21;
                                            highCard21 = p2[i][0];
                                        }
                                    }
                                    if (cardValue[highCard11] > cardValue[highCard21])
                                    {
                                        count++;
                                        continue;
                                    } else if (cardValue[highCard11] == cardValue[highCard21])
                                    {
                                        if (cardValue[highCard12] > cardValue[highCard22])
                                        {
                                            count++;
                                        }
                                    }
                                }
                                continue;
                            }
                            count++;
                            continue;
                        }
                        else if (ThreeOfAKind(p2)) continue;

                        var fre1 = Frequency(p1);
                        var fre2 = Frequency(p2);
                        if (TwoPairs(p1))
                        {
                            if (TwoPairs(p2))
                            {
                                if (fre1.ElementAt(0).Key > fre2.ElementAt(0).Key)
                                {
                                    count++;
                                    continue;
                                } else if (fre1.ElementAt(0).Key == fre2.ElementAt(0).Key)
                                {
                                    if (fre1.ElementAt(1).Key > fre2.ElementAt(1).Key)
                                    {
                                        count++;
                                        continue;
                                    } else if (fre1.ElementAt(1).Key == fre2.ElementAt(1).Key)
                                    {
                                        if (fre1.ElementAt(2).Key > fre2.ElementAt(2).Key)
                                        {
                                            count++;
                                        }
                                    }
                                }
                                continue;
                            }
                            count++;
                            continue;
                        }
                        else if (TwoPairs(p2)) continue;

                        if (OnePair(p1))
                        {
                            if (OnePair(p2))
                            {
                                if (fre1.ElementAt(0).Key > fre2.ElementAt(0).Key)
                                {
                                    count++;
                                    continue;
                                } else if (fre1.ElementAt(0).Key == fre2.ElementAt(0).Key)
                                {
                                    if (fre1.ElementAt(1).Key > fre2.ElementAt(1).Key)
                                    {
                                        count++;
                                        continue;
                                    } else if (fre1.ElementAt(1).Key == fre2.ElementAt(1).Key)
                                    {
                                        if (fre1.ElementAt(2).Key > fre2.ElementAt(2).Key)
                                        {
                                            count++;
                                            continue;
                                        }
                                        else if (fre1.ElementAt(2).Key == fre2.ElementAt(2).Key)
                                        {
                                            if (fre1.ElementAt(3).Key > fre2.ElementAt(3).Key)
                                            {
                                                count++;
                                            }
                                        }
                                    }
                                }
                                continue;
                            }
                            count++;
                            continue;
                        } 
                        else if (OnePair(p2)) continue;
                        bool next = true;
                        for (int i = p1.Length - 1; i > -1  && next; i--)
                        {
                            int pV1 = cardValue[p1[i][0]];
                            int pV2 = cardValue[p2[i][0]];
                            if (pV1 == pV2) continue;
                            if (pV2 < pV1)
                            {
                                count++;
                            }
                            next = false;
                        }
                    }
                    Console.WriteLine(count);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static IOrderedEnumerable<KeyValuePair<int, int>> Frequency(string[] hand)
        {
            Dictionary<int, int> fre = new Dictionary<int, int>();
            for (int i = 0; i < hand.Length; i++)
            {
                if (!fre.TryAdd(cardValue[hand[i][0]], 1)) fre[cardValue[hand[i][0]]]++;
            }
            IOrderedEnumerable<KeyValuePair<int, int>> sortedCollection = fre
                    .OrderByDescending(x => x.Value)
                    .ThenByDescending(x => x.Key);
            return sortedCollection;
        }

        public static bool OnePair(string[] hand)
        {
            Dictionary<char, int> fre = new Dictionary<char, int>();
            for (int i = 0; i < hand.Length; i++)
            {
                char c = hand[i][0];
                if (!fre.TryAdd(c, 1)) fre[c]++;
            }
            foreach (var i in fre)
            {
                if (i.Value == 2) return true;
            }
            return false;
        }

        public static bool TwoPairs(string[] hand)
        {
            Dictionary<char, int> fre = new Dictionary<char, int>();
            int count = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                char c = hand[i][0];
                if (!fre.TryAdd(c, 1)) fre[c]++;
            }
            foreach (var i in fre)
            {
                if (i.Value == 2) count++;
            }
            return count == 2;
        }

        public static bool ThreeOfAKind(string[] hand)
        {
            Dictionary<char, int> fre = new Dictionary<char, int>();
            for (int i = 0; i < hand.Length; i++)
            {
                char c = hand[i][0];
                if (!fre.TryAdd(c, 1)) fre[c]++;
            }
            foreach (var i in fre)
            {
                if (i.Value == 3) return true;
            }
            return false;
        }

        public static bool Straight(string[] hand)
        {
            int start = cardValue[hand[0][0]];
            for (int i = 1; i < hand.Length; i++)
            {
                if (cardValue[hand[i][0]] != start + i) return false;
            }
            return true;
        }

        public static bool Flush(string[] hand)
        {
            char c = hand[0][1];
            for (int i = 1; i < hand.Length; i++)
            {
                if (c != hand[i][1]) return false;
            }
            return true;
        }

        public static bool FullHouse(string[] hand) //doesnt consider 1:4, since four of a kind has priority
        {
            Dictionary<char, int> fre = new Dictionary<char,int>();
            for (int i = 0; i < hand.Length; i++)
            {
                char c = hand[i][0];
                if (!fre.TryAdd(c, 1)) fre[c]++;
            }
            return fre.Count == 2;
        }

        public static bool FourOfAKind(string[] hand)
        {
            char first = hand[0][0];
            char second = hand[1][0];
            int firstN = first == second ? 2 : 1;
            int secondN = 1;
            for (int i = 2; i < hand.Length; i++)
            {
                if (hand[i][0] == first) firstN++;
                if (hand[i][0] == second) secondN++;
            }
            return firstN > 3 || secondN > 3;
        }

        public static bool StraightFlush(string[] hand)
        {
            char suit = hand[0][1];
            int start = cardValue[hand[0][0]];
            for (int i = 1; i < hand.Length; i++)
            {
                if (cardValue[hand[i][0]] != start + i || suit != hand[i][1]) return false;
            }
            return true;
        }

        public static bool RoyalFlush(string[] hand)
        {
            char[] ch = { 'T','J','Q','K','A'};
            char suit = hand[0][1];
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i][0] != ch[i] || hand[i][1] != suit) return false;
            }
            return true;
        }

        public static void Order(string[] hand)
        {
            for (int i = 0; i < hand.Length - 1; i++)
            {
                for (int j = 0; j < hand.Length - i - 1; j++)
                {
                    int l = hand[j][0] - 48;
                    int r = hand[j+1][0] - 48;
                    l = l == 36 ? 10 : l == 26 ? 11 : l == 33 ? 12 : l == 27 ? 13 : l == 17 ? 14 : l;
                    r = r == 36 ? 10 : r == 26 ? 11 : r == 33 ? 12 : r == 27 ? 13 : r == 17 ? 14 : r;
                    if (l > r)
                    {
                        string temp = hand[j];
                        hand[j] = hand[j+1];
                        hand[j+1] = temp;
                    }
                }
            }
        }
    }
}
