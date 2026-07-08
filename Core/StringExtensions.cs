using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class StringExtensions
    {
        public static string TrimSpaces(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Replace(" ", "");
        }
    }
}
