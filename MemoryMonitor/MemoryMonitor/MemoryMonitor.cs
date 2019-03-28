using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMonitor
{
    public class MemoryMonitor
    {
        public bool IsMaxLevelReached { get; private set; } 

        public void CheckMemory(long maxLevel)
        {
            if (GC.GetTotalMemory(false) >= maxLevel)
            {
                Console.WriteLine("Max Level reached");
                IsMaxLevelReached = true;
            }

            Console.WriteLine("Heap size = {0} KB", GC.GetTotalMemory(false) / 1024);
        }
    }
}
