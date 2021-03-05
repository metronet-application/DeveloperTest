using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

class SortCards
{
    public void SortUserCards(string sortOrder, Dictionary<int, string> userCardDict)
    {
        //SortedDictionary<int, string> sortedUserCardDict = new SortedDictionary<int, string>();
        int count = 1;

        if (sortOrder == "ascending")
        {
            var sortedDict = from entry in userCardDict orderby entry.Key ascending select entry;
            foreach (var x in sortedDict)
            {
                Console.WriteLine("Card " + count + ": {0}", x.Value);
                count++;
            }
        }
        if (sortOrder == "descending")
        {
            var sortedDict = from entry in userCardDict orderby entry.Key descending select entry;

            foreach (var x in sortedDict)
            {
                Console.WriteLine("Card " + count + ": {0}", x.Value);
                count++;
            }
        }
    }
}