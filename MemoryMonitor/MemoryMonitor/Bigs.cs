using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryMonitor
{
    public class Bigs : IDisposable
    {
        private string[] StringArr;
        private bool disposedValue = false;
        public static bool IsMaxLevelReached;

        public Bigs()
        {
            StringArr = new string[10000000];
            for (int i = 0; i < StringArr.Length; i++)
            {
                StringArr[i] = i.ToString();
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   
                }

                disposedValue = true;
            }
        }

        ~Bigs()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static void MakeBigObjects()
        {
            Bigs[] bigs = new Bigs[1000];

            for (int i = 0; i < bigs.Length; i++)
            {
                if(IsMaxLevelReached)
                {
                    break;
                }

                bigs[i] = new Bigs();
                Thread.Sleep(5);
                Console.WriteLine($"Attempt {i + 1}");
            }
        }
    }
}
