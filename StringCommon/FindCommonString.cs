using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StringCommon
{
    public class FindCommonString : IFindCommonString
    {
        public FindCommonString() { }
        public string execute(List<string> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var orderedItems = items.OrderBy(item => item.Length);
            Console.WriteLine($"Time to sort list of strings: {stopwatch.ElapsedMilliseconds} milliseconds");
            string result = "";
            if (orderedItems == null || orderedItems.Count() == 0)
            {
                Console.WriteLine("Nothing to see here");
                return result;
            }
            int minLen = orderedItems.First().Length;
            Console.WriteLine("minLen = " + minLen);

            int updateInterval = minLen / 10;

            Console.WriteLine("Working through string set: ");
            for (int i = 0; i < minLen; i++)
            {
                //Console.WriteLine($"Starting Tasks {stopwatch.ElapsedMilliseconds} milliseconds");
                char[] chars = orderedItems.Select(item => item[i]).ToArray();
                //Console.WriteLine($"Finished Ordering {stopwatch.ElapsedMilliseconds} milliseconds");
                if (i % updateInterval == 0)
                {
                    Console.WriteLine($"Working on character {i} of {minLen}, result so far: {resultSoFar(result)}");
                }
                //Console.Write(chars[0]);
                // Check if all items in the array are equal
                bool allEqual = chars.All(c => c == chars[0]);
                //Console.WriteLine($"Determined equal {stopwatch.ElapsedMilliseconds} milliseconds");
                //Console.WriteLine("allEqual: " + allEqual);
                if (allEqual)
                {
                    result += chars[0];
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Finished {minLen}, result: {resultSoFar(result)}");
            Console.WriteLine();
            stopwatch.Stop();
            Console.WriteLine($"Time to find common string: {stopwatch.ElapsedMilliseconds} milliseconds");

            return result;
        }

        public string executeOptimized(List<string> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (items == null || items.Count == 0)
            {
                Console.WriteLine("Nothing to see here");
                return string.Empty;
            }

            // Sort items by length (only once, convert to list for efficient access)
            var orderedItems = items.OrderBy(item => item.Length).ToList();
            Console.WriteLine($"Time to sort list of strings: {stopwatch.ElapsedMilliseconds} milliseconds");

            // Get the minimum length of the strings
            int minLen = orderedItems.First().Length;
            Console.WriteLine("minLen = " + minLen);

            int updateInterval = Math.Max(1, minLen / 10);  // Avoid division by zero if minLen is 0
            Console.WriteLine("Working through string set: ");

            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < minLen; i++)
            {
                if (i % updateInterval == 0)
                {
                    Console.WriteLine($"Working on character {i} of {minLen}, result so far: {resultSoFar(resultBuilder.ToString())}");
                }

                // Compare characters at position i across all strings
                char firstChar = orderedItems[0][i]; // Get the character from the first item
                bool allEqual = true;

                for (int j = 1; j < orderedItems.Count; j++)
                {
                    if (orderedItems[j][i] != firstChar)
                    {
                        allEqual = false;
                        break;
                    }
                }

                // If all characters are the same, append to the result
                if (allEqual)
                {
                    resultBuilder.Append(firstChar);
                }
                else
                {
                    break;  // Stop if characters are not all equal
                }
            }

            string result = resultBuilder.ToString();
            Console.WriteLine($"Finished {minLen}, result: {resultSoFar(result)}");
            stopwatch.Stop();
            Console.WriteLine($"Time to find common string: {stopwatch.ElapsedMilliseconds} milliseconds");

            return result;
        }
        private object resultSoFar(string result)
        {
            return result.Length < 20 ? result :
                result.Substring(0, 10) + "..." + result.Substring(result.Length - 10);
        }
    }
}
