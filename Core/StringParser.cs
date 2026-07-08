using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class StringParser
    {
        public static List<Output> Parse(string s)
        {
            string trimmed = s.TrimSpaces();
            int i = trimmed.StartsWith('(') ? 1 : 0;
            return Parse(trimmed, ref i);
        }

        /// <summary>
        /// Recursion method to parse the whole string and extract words 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static List<Output> Parse(string s, ref int i)
        {
            var result = new List<Output>();
            if (!string.IsNullOrWhiteSpace(s))
            {
                var word = new StringBuilder();

                while (i < s.Length && s[i] != ')')
                {
                    char c = s[i++];
                    if (c == '(') // means there is children
                    {
                        AddOutput(result, word, Parse(s, ref i));
                        i++;
                    }
                    else if (c == ',')
                    {
                        AddOutput(result, word);
                    }
                    else word.Append(c);
                }
                AddOutput(result, word);
            }
            return result;
        }
        
        /// <summary>
        /// Helper method (repeated code moved to here)
        /// </summary>
        /// <param name="result"></param>
        /// <param name="name"></param>
        /// <param name="children"></param>
        private static void AddOutput(List<Output> result, StringBuilder name, List<Output>? children = null)
        {
            if (name.Length > 0)
            {
                var output = new Output(name.ToString());
                if (children != null && children.Count > 0)
                    output.Children = children;

                result.Add(output);
                name.Clear();
            }
        }
    }
}
