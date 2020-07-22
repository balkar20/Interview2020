using System;
using System.Threading;

namespace Abort
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread mt1 = new MyThread("Мой поток");
            Thread.Sleep(1000);
            Console.WriteLine("Прерывание потока");
            mt1.Thrd.Abort();

            // Ожидание прерывания
            mt1.Thrd.Join();

            Console.WriteLine("Основной поток прерван");
            Console.ReadLine();
        }
    }

    class MyThread
    {
        public Thread Thrd;

        public MyThread(string name)
        {
            MyThread mt1 = new MyThread("Мой поток");
            Thread.Sleep(1000);
            Console.WriteLine("Прерывание потока");
            mt1.Thrd.Abort();

            // Ожидание прерывания
            mt1.Thrd.Join();

            Console.WriteLine("Основной поток прерван");
            Console.ReadLine();
        }

        // Точка входа в поток
        void Run()
        {
            Console.WriteLine(Thrd.Name + " начат");
            for (int i = 1; i <= 1000; i++)
            {
                try
                {
                    Console.Write(i + " ");
                    if ((i % 10) == 0)
                    {
                        Console.WriteLine();
                        Thread.Sleep(250);
                    }
                }
                catch (ThreadAbortException exc)
                {
                    if ((int)exc.ExceptionState == 0)
                    {
                        Console.WriteLine("Прерывание отменено! Код завершения: "
                                          + exc.ExceptionState);
                        Thread.ResetAbort();
                    }
                    else
                        Console.WriteLine("Поток прерван, код завершения "
                                          + exc.ExceptionState);
                }

            }
            Console.WriteLine(Thrd.Name + " завершен");
        }
    }
}
