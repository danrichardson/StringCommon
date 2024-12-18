using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommon
{
    public class SortEm : ISortEm
    {
        public SortEm() { }
        public string execute(List<string> items)
        {
            items.OrderBy(item => item);
            string result = "";
            if (items == null || items.Count() == 0)
            {
                Console.WriteLine("Nothing to see here");
                return result;
            }
            int minLen = items.First().Length;

            Console.WriteLine("minLen = " + minLen);
            for (int i = 0; i < minLen; i++)
            {
                char[] chars = items.Select(item => item[i]).ToArray();
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
