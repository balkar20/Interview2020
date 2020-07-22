using System;
using System.Threading;

namespace MonitorPulseWait
{
    class Program
    {
        static void Main(string[] args)
        {
            TickTock tt = new TickTock();
            MyThread mt1 = new MyThread("Tick", tt);
            MyThread mt2 = new MyThread("Tock", tt);
            mt1.thrd.Join();
            mt2.thrd.Join();

            Console.WriteLine("Часы остановлены");
            Console.ReadLine();
        }
    }

    class TickTock
    {
        private object lockOn = new object();

        public void Tick(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    // Остановить часы
                    Monitor.Pulse(lockOn);
                    return;
                }

                Console.Write("Тик ");
                // Разрешить выполнение метода Tock()
                Monitor.Pulse(lockOn);

                // Ожидать завершение Tock()
                Monitor.Wait(lockOn);
            }
        }

        public void Tock(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    Monitor.Pulse(lockOn);
                    return;
                }

                Console.WriteLine("так");
                Monitor.Pulse(lockOn);
                Monitor.Wait(lockOn);
            }
        }
    }

    class MyThread
    {
        public Thread thrd;
        TickTock ttobj;

        // Новый поток
        public MyThread(string name, TickTock tt)
        {
            thrd = new Thread(this.Run);
            ttobj = tt;
            thrd.Name = name;
            thrd.Start();
        }

        void Run()
        {
            if (thrd.Name == "Tick")
            {
                for (int i = 0; i < 5; i++)
                    ttobj.Tick(true);
                ttobj.Tick(false);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                    ttobj.Tock(true);
                ttobj.Tock(false);
            }
        }
    }
}
