// See https://aka.ms/new-console-template for more information
using StringCommon;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace FunWithStrings
{
    class Program
    {
        static void Main()
        {
            // Create a list of strings
            List<string> stringList = new List<string> { "Apple", "AppleBar", "AppleFoo", "Appleicious" };
            // Use ForEach to iterate through the list and write each item to the console
            stringList.ForEach(item => Console.WriteLine(item));
            FindCommonString findCommonString = new FindCommonString();
            Console.WriteLine("Result of findCommonString: " + findCommonString.execute(stringList));
        }
    }
}