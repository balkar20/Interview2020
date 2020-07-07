using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MergeJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MergeJoin
    {
        public async Task Meth()
        {
            
        }

        // Assume that left and right are already sorted
        public static Relation Merge(Relation left, Relation right)
        {
            Relation output = new Relation();
            while (!left.IsPastEnd() && !right.IsPastEnd())
            {
                if (left.Key == right.Key)
                {
                    output.Add(left.Key);
                    left.Advance();
                    right.Advance();
                }
                else if (left.Key < right.Key)
                    left.Advance();
                else // if (left.Key > right.Key)
                    right.Advance();
            }
            return output;
        }
    }

    public class Relation
    {
        private List<int> list;
        public const int ENDPOS = -1;

        public int position = 0;
        public int Position
        {
            get { return position; }
        }

        public int Key
        {
            get { return list[position]; }
        }

        public bool Advance()
        {
            if (position == list.Count - 1 || position == ENDPOS)
            {
                position = ENDPOS;
                return false;
            }
            position++;
            return true;
        }

        public void Add(int key)
        {
            list.Add(key);
        }

        public bool IsPastEnd()
        {
            return position == ENDPOS;
        }

        public void Print()
        {
            foreach (int key in list)
                Console.WriteLine(key);
        }

        public Relation(List<int> list)
        {
            this.list = list;
        }

        public Relation()
        {
            this.list = new List<int>();
        }
    }
}
