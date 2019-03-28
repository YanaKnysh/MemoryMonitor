using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Bigs.MakeBigObjects);
            thread.IsBackground = true; //1 variant - make thread background
            thread.Start();

            MemoryMonitor memoryMonitor = new MemoryMonitor();

            for (int i = 0; i < 20; i++)
            {
                memoryMonitor.CheckMemory(121666928);

                if (memoryMonitor.IsMaxLevelReached)
                {
                    Bigs.IsMaxLevelReached = true; //2 variant - add field and change it's value
                    break;
                }

                Thread.Sleep(100);
            }
        }
    }
}
