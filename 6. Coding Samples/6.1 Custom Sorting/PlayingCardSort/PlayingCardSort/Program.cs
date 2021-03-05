using System;
using System.Collections.Generic;


namespace PlayingCardSort
{
    class Program
    {
        static void Main(string[] args)
        {            
            GetCards getCards = new GetCards();
            SortCards sortCards = new SortCards();

            //User provides cards and how they should be sorted, ascending/descending.
            string[] userInput = getCards.GetInputCards();
            string sortOrder = getCards.GetSortOrder();

            //converts cards to card value and adds value and card description to the dictionary.
            Dictionary<int,string> userCards = getCards.ValidateCards(userInput);

            //SortCards sortCards = new SortCards();
            sortCards.SortUserCards(sortOrder,userCards);

            //Console.ReadKey();
        }
    }
}
