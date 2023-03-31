using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoThreading
{
    public class AWorker
    {
        private static bool done = false;    // Static fields are shared between all threads


        private Action<int> HalloMethod;  // reference til en metode void XXX(int i)

        public AWorker()
        {
        }

        public void Start()
        {
            //HalloMethod = (t) => { Console.WriteLine( "Udskriver tal "  + t); };
            HalloMethod = XXX;
            HalloMethod(9);

            //StartThreadTest();

            //StartTaskTest();



            Thread.Sleep(5000);
        }

        public void XXX(int tal)
        {
            Console.WriteLine("tal i anden er " + tal*tal);
        }
        
        /*
         *
         * THREADS
         *
         */

        private void StartThreadTest()
        {
            new Thread(Go).Start();  // ny tråd
            Go();
        }

        private void Go()
        {
            if (!done) { Thread.Sleep(1); done = true; Console.WriteLine("Done"); }
        }



        /*
         *
         * TASKS
         *
         */

        private void StartTaskTest()
        {
            Task.Run(() => DoWork("Number One", ConsoleColor.Red));
            Task.Run(() => DoWork("Number Two", ConsoleColor.Green));
        }

        private void DoWork(String name, ConsoleColor colour)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine($"Name {name} no={i}");
            }
        }
    }
}
