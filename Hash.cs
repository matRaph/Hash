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
        public Element?[] Elements{ get; set; }
        public Hash(int size)
        {
            this.Size = size;
            this.Elements = new Element[size];
        }

        private int HashFunc(object key)
        {
            return (this.Size % key.GetHashCode());
        }

        public object FindElement(object Key)
        {
            int index = HashFunc(Key);
            int count = 0;

            //Percorre o array de forma circular
            while (count != this.Size)
            {
                Element cell = Elements[index];
                //Se encontrar uma célula vazia
                if (cell == null)
                {
                    throw new NO_SUCH_KEY_EXCEPTION("Chave não encontrada");
                }
                //Se encontrar a chave retorna o elemento
                else if (cell.Key.Equals(Key))
                {
                    return cell.Value;
                }
                //Se encontrar o fim do array, retorna para começo dele
                else if (count == this.Size - 1) index = 0;

                index++;
                count++;
            }
            throw new NO_SUCH_KEY_EXCEPTION("Chave não encontrada");
        }
    }
}
