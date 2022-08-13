using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    internal class NO_SUCH_KEY_EXCEPTION : Exception
    {
        public NO_SUCH_KEY_EXCEPTION(string message) : base(message) { }
    }
}
