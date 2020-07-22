using System;
using System.Text;
using System.Threading;

namespace ManualResetEvent
{
    class MyThread
    {
        public Thread Thrd;
        System.Threading.ManualResetEvent mre;

        public MyThread(string name, System.Threading.ManualResetEvent evt)
        {
            Thrd = new Thread(this.Run);
            Thrd.Name = name;
            mre = evt;
            Thrd.Start();
        }

        void Run()
        {
            Console.WriteLine("Внутри потока " + Thrd.Name);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thrd.Name);
                Thread.Sleep(500);
            }

            Console.WriteLine(Thrd.Name + " завершен!");

            // Уведомление о событии
            mre.Set();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            System.Threading.ManualResetEvent evtObj = new System.Threading.ManualResetEvent(false);

            MyThread mt1 = new MyThread("Событийный поток 1", evtObj);

            Console.WriteLine("Основной поток ожидает событие");

            evtObj.WaitOne();

            Console.WriteLine("Основной поток получил уведомление о событии от первого потока");

            evtObj.Reset();

            mt1 = new MyThread("Событийный поток 2", evtObj);

            evtObj.WaitOne();

            Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
            Console.ReadLine();
        }
    }
}
