using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace platformPerformer {
    class Timer {


        private long startTime;
        private long endTime;

        private long freq;

        /// <summary>
        /// INSURES THE JIT MAKES THIS EFFECIENT ENOUGHT.. pretty hack.
        /// </summary>
        static Timer() {
            Timer t = new Timer();
            t.start();
            t.stop();
            t.getDifferenceInTimers();
            t.getDiffTimeInSec();
            t.getDiffTimeInMs();
        }

        public Timer() {
            if ( QueryPerformanceFrequency( out freq ) == false ) {
                throw new Win32Exception();// high-performance counter not supported
            }
            //exercise the runtime system to make this fast enough / precise enough.

        }


        public long getDiffTimeInMs() {
            return getDifferenceInTimers() / (freq / 1000);
        }

        public void start() {
            Thread.Sleep( 0 );
            QueryPerformanceCounter( out startTime );
        }

        public void stop() {
            QueryPerformanceCounter( out endTime );
        }

        public double getDiffTimeInSec() {
            return (double)(endTime - startTime) / (double)freq;
        }

        public long getDifferenceInTimers() {
            return endTime - startTime;
        }

        public static long getCurrentCpuTime() {
            long temp;
            QueryPerformanceCounter( out temp );
            return temp;
        }

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
         out long lpPerformanceCount );

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
            out long lpFrequency );


    }
}
