using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{

    internal class Hash
    {
        internal class Element
        {
            public object Key { get; set; }
            public object Value { get; set; }

            public Element(object value)
            {
                Key = this.Key;
                Value = value;
            }

            public override string ToString()
            {
                return $"{this.Key}: {this.Value}";
            }
        }

        public int Size{ get; set; }
        public Element[] Elements{ get; set; }
        public Hash(int size)
        {
            this.Size = size;
            this.Elements = new Element[size];
        }

        public int HashFunc(object key)
        {
            return (this.Size % key.GetHashCode());
        }

    }
}
