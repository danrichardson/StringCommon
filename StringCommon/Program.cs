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

            
            List<string> stringList = StringGenerator.GenerateStrings(
                numberOfStrings: 5,
                                //lengthOfEachString: 100, 
                                //lengthOfCommonChars: 99, 
                                //lengthOfEachString: 100000000,
                                //lengthOfCommonChars: 99990000,
                                lengthOfEachString: 100000,
                                lengthOfCommonChars: 99900,
                                allCaps: true);

            foreach (var str in stringList)
            {
                //Console.WriteLine(str);
            }

            // Create a list of strings
            //List<string> stringList = new List<string> { "Apple", "AppleBar", "AppleFoo", "Appleicious" };
            // Use ForEach to iterate through the list and write each item to the console
            //stringList.ForEach(item => Console.WriteLine(item));
            FindCommonString findCommonString = new FindCommonString();
            var commonString = findCommonString.execute(stringList);
            var commonString2 = findCommonString.executeOptimized(stringList);
            //Console.WriteLine(commonString);
            Console.WriteLine("Result of findCommonString: " + (commonString.Length < 20 ? commonString :
                commonString.Substring(0, 10) + "..." + commonString2.Substring(commonString2.Length - 10)));
            Console.WriteLine("Result of findCommonString: " + (commonString.Length < 20 ? commonString :
                commonString2.Substring(0, 10) + "..." + commonString2.Substring(commonString2.Length - 10))); 
        }
    }
}