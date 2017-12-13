using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Timing
    {
        DateTime startTime;
        TimeSpan duration;//
        public Timing()
        {
            startTime = DateTime.Now; ;
            duration = new TimeSpan(0);
        }
        public void StopTIme()
        {
            var currentTime = DateTime.Now; //Process.GetCurrentProcess().Threads[0].UserProcessorTime;
            duration = currentTime.Subtract(startTime);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startTime = DateTime.Now;// Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
}
