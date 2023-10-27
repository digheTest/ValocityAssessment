using System;

namespace CardOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intUserCard;
            int intComputerCard;
            int intUserTotal = 0;
            int intComputerTotal = 0;
            int intSuit;
            int intCount = 0;

            string strUserSuit;
            string strComputerSuit;
            string strUserCard;
            string strComputerCard;
            string strResult = "";

            string[] strCardSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] strCardNames = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };


            int[] intDeck = new int[52];

            ShuffleDeck(ref intDeck);

            for (int x = 0; x < 26; x++)
            {
                try
                {
                    intUserCard = ChooseYourCard(intDeck, ref intCount, out
                  intSuit);
                    strUserSuit = strCardSuits[intSuit];
                    strUserCard = strCardNames[intUserCard];

                    intComputerCard = ChooseYourCard(intDeck, ref intCount, out
                       intSuit);
                    strComputerSuit = strCardSuits[intSuit];
                    strComputerCard = strCardNames[intComputerCard];

                    if (intUserCard > intComputerCard)
                    {

                        intUserTotal += 1;
                        strResult = "User wins!!!";

                    }

                    else if (intUserCard < intComputerCard)
                    {

                        intComputerTotal += 1;
                        strResult = "Computer wins!!!";

                    }

                    else if (intUserCard == intComputerCard)
                    {

                        intUserTotal += 1;
                        intComputerTotal += 1;

                        strResult = "Tie.!!!";

                    }
                    Console.WriteLine("Deal             #{0}", x + 1);

                    Console.WriteLine("User             : {0} of {1}", strUserCard, strUserSuit);
                    Console.WriteLine("Computer         : {0} of {1}", strComputerCard, strComputerSuit);
                    Console.WriteLine("{0}", strResult);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("User Score       : {0}", intUserTotal);
                    Console.WriteLine("Computer Score   : {0}", intComputerTotal);
                    Console.WriteLine("=========================================");
                    Console.ReadKey();
                }
                catch (Exception)
                {

                    Console.WriteLine("Card selections were not correct Game restarted!!!");
                }
            }
        }
        /// <summary>
        /// This function gets array of integer and shuffle deck randomly.
        /// </summary>
        /// <param name="Deck">int[]</param>
        public static void ShuffleDeck(ref int[] Deck)
        {

            int c;

            Random rndCards = new Random();

            for (c = 0; c < 52; c++)
            {

                Deck[c] = rndCards.Next(1, 52);

            }

        }
        /// <summary>
        /// This function gets array of int, count of cards and returns suit for each player
        /// </summary>
        /// <param name="Deck">int[]</param>
        /// <param name="count">integer</param>
        /// <param name="Suit">integer</param>
        /// <returns>int</returns>
        public static int ChooseYourCard(int[] Deck, ref int count, out int Suit)
        {
            int Card;

            Card = Deck[count];

            count++;

            Suit = (Card - 1) % 4;

            return (Card - 1) / 4 + 1;

        }
    }
}
