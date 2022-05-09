using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimer
{
    internal class Win32
    {
            /// <summary>TimeBeginPeriod(). See the Windows API documentation for details.</summary>

            [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod", SetLastError = true)]
            public static extern uint TimeBeginPeriod(uint uMilliseconds);

            /// <summary>TimeEndPeriod(). See the Windows API documentation for details.</summary>

            [DllImport("winmm.dll", EntryPoint = "timeEndPeriod", SetLastError = true)]
            public static extern uint TimeEndPeriod(uint uMilliseconds);
    }
}
