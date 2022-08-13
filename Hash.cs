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

            public Element(object Value, object Key)
            {
                this.Key = Key;
                this.Value = Value;
            }

            public override string ToString()
            {
                return $"{this.Key}: {this.Value}";
            }
        }

        public int Size { get; set; }
        public Element?[] Elements { get; set; }
        public Hash(int lenght)
        {
            this.Size = 0;
            this.Elements = new Element[lenght];
        }

        private int HashFunc(object key)
        {
            return Math.Abs(key.GetHashCode() % (this.Elements.Length));
        }

        public object FindElement(object Key)
        {
            int index = HashFunc(Key);
            int count = 0;

            //Utilizando o linear probing
            //Percorre o array de forma circular
            while (this.Elements[index] != null)
            {
                if (this.Elements[index].Key.Equals(Key))
                {
                    return this.Elements[index].Value;
                }

                if (count == this.Elements.Length)
                {
                    throw new NO_SUCH_KEY_EXCEPTION("Chave informada não existe");
                }

                if (index == this.Elements.Length - 1) index = 0;

                else index++;

                count++;
            }

            throw new NO_SUCH_KEY_EXCEPTION("Chave informada não existe");
        }

        public void Show()
        {
            for (int i = 0; i < this.Elements.Length; i++)
            {
                if (this.Elements[i] == null)
                {
                    Console.Write("Null ");
                    continue;
                }
                Console.Write($"({this.Elements[i]}) ");
            }
            Console.WriteLine();
        }

        public void InsertElement(object key, object value)
        {
            if (this.Size == this.Elements.Length)
            {
                DoubleArray();
            }

            try
            {
                FindElement(key);
                throw new KEY_ALREADY_EXISTS_EXCEPTION("A chave já existe");
            }
            catch (NO_SUCH_KEY_EXCEPTION)
            {


                int index = HashFunc(key);
                int count = 0;
                
                while (this.Elements[index] != null)
                {
                    index++;
                    if (index == this.Elements.Length) index = 0;
                }
                Element newElement = new(value, key);
                this.Elements[index] = newElement;
            }
            this.Size++;
        }


        private void DoubleArray()
        {
            Element[] newElements = new Element[this.Elements.Length * 2];

            for (int i = 0; i < this.Elements.Length; i++)
            {
                Element newElement = this.Elements[i];

                if (newElement == null) continue;
                int index = this.HashFunc(newElement.Key);

                while (newElements[index] != null)
                {
                    index++;
                    if (index == this.Elements.Length)
                    {
                        index = 0;
                    }
                }

                newElements[i] = newElement;
            }

            this.Elements = newElements;
        }

        public object RemoveItem(object Key)
        {
            int index = HashFunc(Key);
            int count = 0;

            //Utilizando o linear probing
            //Percorre o array de forma circular
            while (this.Elements[index] != null)
            {
                if (this.Elements[index].Key.Equals(Key))
                {
                    object ret = this.Elements[index].Value;
                    this.Elements[index] = null;
                    this.Size--;
                    return ret;
                }

                if (count == this.Elements.Length) break;
                if (index == this.Elements.Length - 1) index = 0;
                else index++;

                count++;
            }
            throw new NO_SUCH_KEY_EXCEPTION("Chave não encontrada");
        }

    }

}
