using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    internal class KEY_ALREADY_EXISTS_EXCEPTION : Exception
    {
        public KEY_ALREADY_EXISTS_EXCEPTION(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
