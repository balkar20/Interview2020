using System;

namespace Arena2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int.MaxValue is 2,147,483,647.
            const int ConstantMax = int.MaxValue;
            int int1;
            int int2;
            int variableMax = 2147483647;

            // The following statements are checked by default at compile time. They do not
            // compile.
            //int1 = 2147483647 + 10;
            //int1 = ConstantMax + 10;

            // To enable the assignments to int1 to compile and run, place them inside 
            // an unchecked block or expression. The following statements compile and
            // run.
            unchecked
            {
                int1 = 2147483647 + 10;
            }

            checked
            {
                int1 = 2147483647;
            }
            

            Console.WriteLine($"{int1}");
            //ITest test = new Test(2);
            //MethTest(test);
            //test.ShowI();
            //Console.ReadLine();
        }

        static void MethTest(ITest test)
        {
            test.i = 10;
        }
    }

    public struct Test:ITest
    {
        public Test(int i)
        {
            this.i = i;
        }

        public int i { get; set; }

        public void ShowI()
        {
            Console.WriteLine($"Test i: {this.i}");
        }
    }

    public interface ITest
    {
        int i { get; set; }
        void ShowI();
    }
}
