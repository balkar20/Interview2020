using System;
using System.Collections.Generic;
using System.Linq;

namespace Arena3
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = Get().First();
            var a2 = Get().ToList();

            Console.WriteLine($"First : {a1}");
            Console.WriteLine($"List : ");

            foreach (var i in a2)
            {
                Console.WriteLine($"el: {i}");
            }

            foreach (var i in GetAuth().ToList())
            {
                Console.WriteLine($"el: {i}");
            }
            

        }

        static IEnumerable<int> Get()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return 5;
            }
            //for(; ;)
            //yield return 5;
        }

        static IEnumerable<int> GetAuth()
        {
            throw new Exception("xxx");
            yield return 5;
        }


    }
}
