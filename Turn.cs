using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen
{
    class Program
    {
        static void Main()
        {
            Turn<int> testTurn = new Turn<int>();
            testTurn.AddElement(2);
            testTurn.AddElement(3);
            testTurn.AddElement(4);
            testTurn.AddElement(5);
            Console.WriteLine(testTurn.TakeElement());
            Console.WriteLine(testTurn.TakeElement());
            Console.WriteLine(testTurn.TakeElement());
            Console.WriteLine(testTurn.TakeElement());
            Console.WriteLine(testTurn.TakeElement());
            Console.WriteLine(testTurn.TakeElement());



            Console.WriteLine();
        }
    }

    class Element<T>
    {
        public T Value
        {
            get;
            set;
        }

        public Element(T value)
        {
            Value = value;
        }


        public Element<T> Next
        {
            get;
            set;
        }

        public Element<T> Prev
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }

    class Turn<T>
    {
        Element<T> FirstElement;
        Element<T> LastElement;

        public void AddElement(T value)
        {
            if (FirstElement == null)
            {
                FirstElement = new Element<T>(value);
                LastElement = FirstElement;
                return;
            }
            else
            {
                Element<T> temperElement;
                if (FirstElement.Next == null)
                {
                    temperElement = new Element<T>(value);
                    FirstElement.Next = temperElement;
                    temperElement.Prev = FirstElement;

                    LastElement = temperElement;
                    return;
                }
                else
                {
                    temperElement = new Element<T>(value);

                    LastElement.Next = temperElement;
                    temperElement.Prev = LastElement;

                    LastElement = temperElement;
                    return;
                }
            }
        }

        public Element<T> TakeElement()
        {
            if (FirstElement == null)
            {
                try
                {
                    throw new MyFirstException("Turn is empty");
                }


                catch (MyFirstException exOb)
                {
                    Console.WriteLine(exOb.Message);
                }
            }
            else
            {
                // новый объект для предотвращения доступа к остальным ссылкам в очереди
                // представляет собой только данные, без ссылок
                Element<T> temperElement = new Element<T>(FirstElement.Value);
                FirstElement = FirstElement.Next;
                return temperElement;
            }
            return null;
        }

    }

    public class MyFirstException : Exception
    {
        public MyFirstException() : base() { }
        public MyFirstException(string message) : base(message) { }
        public MyFirstException(string message, Exception inner) : base(message, inner) { }

        protected MyFirstException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        {

        }
    }

}

