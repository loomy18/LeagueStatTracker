using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApiDriver.Utility
{
   public static class StringUtil
   {
        public static string ExceptBlanks(string str)
        {
            if (str == null) return "";
            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (!char.IsWhiteSpace(c))
                    sb.Append(Char.ToLower(c));
            }
            return sb.ToString();
        }
    }
 
}
