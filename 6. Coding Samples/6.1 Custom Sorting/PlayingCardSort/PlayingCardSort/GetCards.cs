using System;
using System.Collections.Generic;
using System.Linq;

class GetCards
{
    public string[] GetInputCards()
    {
        Console.WriteLine("Please input the playing cards to be sorted, e.g. Queen of Hearts, 9 of Spades.");
        string getCards = Console.ReadLine();
        while (getCards == "")
        {
            Console.WriteLine("Please provide the playing cards to be sorted, \"[card] of [suit], [card] of [suit]\".");
            getCards = Console.ReadLine();
        }

        string[] inputCards = getCards.Split(',');
        return inputCards;            
    }

    public Dictionary<int,string> ValidateCards(string[] userCards)
    {
        Dictionary<int, string> userCardDict = new Dictionary<int, string>();
        for (int i = 0; i < userCards.Length; i++)
        {
            string card = userCards[i].Trim();
            string cardValue = card.Substring(0, card.IndexOf(" of "));
            string cardSuit = card.Substring(card.IndexOf(" of ") + 4, (card.Length - card.IndexOf(" of ") - 4));

            //Console.WriteLine(cardValue);
            //Console.WriteLine(cardSuit);
            
            int cardValueInt = 0;
            int cardSuitInt = 0;

            switch (cardValue)
            {
                case "2":
                    cardValueInt = 1;
                    break;
                case "3":
                    cardValueInt = 2;
                    break;
                case "4":
                    cardValueInt = 3;
                    break;
                case "5":
                    cardValueInt = 4;
                    break;
                case "6":
                    cardValueInt = 5;
                    break;
                case "7":
                    cardValueInt = 6;
                    break;
                case "8":
                    cardValueInt = 7;
                    break;
                case "9":
                    cardValueInt = 8;
                    break;
                case "10":
                    cardValueInt = 9;
                    break;
                case "Jack":
                    cardValueInt = 10;
                    break;
                case "Queen":
                    cardValueInt = 11;
                    break;
                case "King":
                    cardValueInt = 12;
                    break;
                case "Ace":
                    cardValueInt = 13;
                    break;
                default:
                    Console.WriteLine(userCards[i].ToString() + "contains an incorrect format.");
                    break;
            }

            switch (cardSuit)
            {
                case "Hearts":
                    cardSuitInt = 0;
                    break;
                case "Diamonds":
                    cardSuitInt = 13;
                    break;
                case "Clubs":
                    cardSuitInt = 26;
                    break;
                case "Spades":
                    cardSuitInt = 39;
                    break;
                default:
                    Console.WriteLine(userCards[i].ToString() + "contains an incorrect format.");
                    break;
            }

            int cardCount = cardValueInt + cardSuitInt;
            
            //Console.WriteLine(cardCount);

            userCardDict.Add(cardCount, card);

        }
        return userCardDict;
    }
   public string GetSortOrder()
    {
        string[] sortOrder = { "ascending", "descending" };

        //Console.WriteLine("How would you like the list to be sorted? (Ascending or Descending)");
        string inputSortType = Console.ReadLine().ToLower().Trim();
        while(!sortOrder.Contains(inputSortType))
            {
            Console.WriteLine("Please type ascending or descending.");
            inputSortType = Console.ReadLine().ToLower().Trim();
        }
        return inputSortType;
    }
}
