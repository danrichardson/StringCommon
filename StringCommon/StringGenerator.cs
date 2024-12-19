using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StringCommon
{
    public class StringGenerator
    {
        private static Random _random = new Random();

        public static List<string> GenerateStrings(int numberOfStrings, int lengthOfEachString, int lengthOfCommonChars, bool allCaps)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (lengthOfCommonChars > lengthOfEachString)
            {
                throw new ArgumentException("Z cannot be greater than Y");
            }
            Console.WriteLine($"Generating {numberOfStrings} strings {lengthOfEachString} long with {lengthOfCommonChars} chars in common");
            List<string> stringsList = new List<string>();

            // Generate a base string with Z common characters
            string commonPart = GenerateRandomString(lengthOfCommonChars, allCaps);

            for (int i = 0; i < numberOfStrings; i++)
            {
                // Start each string with the common part
                char[] str = new char[lengthOfEachString];
                for (int j = 0; j < lengthOfCommonChars; j++)
                {
                    str[j] = commonPart[j];
                }

                // Fill the rest of the string with random characters
                for (int j = lengthOfCommonChars; j < lengthOfEachString; j++)
                {
                    str[j] = (char)_random.Next('a', 'z' + 1);  // Random lowercase letter
                }

                // Add the generated string to the list
                stringsList.Add(new string(str));
            }
            stopwatch.Stop();
            Console.WriteLine($"Time to generate string set: {stopwatch.ElapsedMilliseconds} milliseconds");

            return stringsList;
        }

        // Helper method to generate a random string of a given length
        private static string GenerateRandomString(int length, bool allCaps)
        {
            char[] randomString = new char[length];
            for (int i = 0; i < length; i++)
            {
                randomString[i] = allCaps ? (char)_random.Next('A', 'Z' + 1) : (char)_random.Next('a', 'z' + 1);
            }
            return new string(randomString);
        }
    }
}
