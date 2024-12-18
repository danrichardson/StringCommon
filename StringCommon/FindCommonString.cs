using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommon
{
    public class FindCommonString : IFindCommonString
    {
        public FindCommonString() { }
        public string execute(List<string> items)
        {
            var orderedItems = items.OrderBy(item => item.Length);
            string result = "";
            if (orderedItems == null || orderedItems.Count() == 0)
            {
                Console.WriteLine("Nothing to see here");
                return result;
            }
            int minLen = orderedItems.First().Length;

            Console.WriteLine("minLen = " + minLen);
            for (int i = 0; i < minLen; i++)
            {
                char[] chars = orderedItems.Select(item => item[i]).ToArray();
                Console.WriteLine("char: " + chars[0]);
                // Check if all items in the array are equal
                bool allEqual = chars.All(c => c == chars[0]);
                Console.WriteLine("allEqual: " + allEqual);
                if (allEqual)
                {
                    result += chars[0];
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
