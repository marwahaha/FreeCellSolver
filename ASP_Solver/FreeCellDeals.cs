// following code was largely borrowed from https://rosettacode.org/wiki/Deal_cards_for_FreeCell#Shorter_version
// it was then commented, and modified to fit my needs

using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace FreeCellDeals
{
	public class Rand {
		long _seed;
		public Rand(int seed=1) {
			_seed = seed;
		}
		public int Next() {
			return (int) ((_seed = (_seed * 214013 + 2531011) & int.MaxValue) >> 16);
		}
	}
 
	public class Card {
		private static readonly string kSuits = "♣♦♥♠";
		private static readonly string kValues = "A23456789TJQK";
		public int Value { get; set; }
		public int Suit { get; set; }
		public Card(int rawvalue=0) : this(rawvalue / 4, rawvalue % 4) {
		}
		public Card(int value, int suit) {
			Value = value;  Suit = suit;
		}
		public override string ToString() {
			return string.Format("{0}{1}", kValues[Value], kSuits[Suit]);
		}
	}
 
	public class Deck {
		public List<Card> Cards;

                // build suffled deck
		public Deck(int seed) {
			var r = new Rand(seed);
			Cards = new List<Card>();
			for (int i=0; i < 52; i++){
                            Cards.Add(new Card(51 - i));
                            Console.WriteLine("Card: {0}\n", Cards[i]);
                        }
                        // Deck is backwards so we turn it so that we can deal from the top
			for (int i=0; i < 51; i++) {
				int j = 51 - r.Next() % (52 - i);
				Card tmp = Cards[i];  Cards[i] = Cards[j];  Cards[j] = tmp;
			}
		}

                // remove cards from the deck
                // method I added to 
                public bool RemoveCards(int bound){
                    // check bounds
                    if(bound <= 1 || bound >= 14)
                        return false;

                    // remove all cards greater than max value
                    for (int i=0; i < Cards.Count; i++){
                        if(Cards[i].Value <= bound){
                            Cards.RemoveAt(i);
                            i--;
                        }
                    }

                    return true;
                }

                // override ToString to print the deck
		public override string ToString() {
			var sb = new StringBuilder();
			for (int i=0; i < Cards.Count; i++) {
				sb.Append(Cards[i].ToString());
				sb.Append(i % 8 == 7 ? "\n" : " ");
			}
			return sb.ToString();
		}
	}

        public class Solver {
        }
 
	class Program {
		public static void Main(string[] args) {
                        Deck deck1 = new Deck(1);
			Console.WriteLine("Deck 1\n{0}\n", new Deck(1));

                        deck1.RemoveCards(5);
                        Console.WriteLine("Deck1 with through five sorted\n{0}\n", deck1);

			Console.WriteLine("Deck 617\n{0}\n", new Deck(617));
		}
	}
}
