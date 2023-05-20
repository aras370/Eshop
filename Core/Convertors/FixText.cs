using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public  class FixText
    {
        public static string FixEmail(string parameter)
        {
            return parameter.Trim().ToLower();
        }
    }
}
