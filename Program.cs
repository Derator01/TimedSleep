using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimedSleep;

public static partial class Program
{
    [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
    private static void Main(string[] arg)
    {
        if (arg[0] == "a")
        {
            foreach (var process in Process.GetProcessesByName("TimedSleep"))
                process.Kill();
            return;
        }

        Thread.Sleep(int.Parse(arg[0]));

        SetSuspendState(false, true, false); ;
    }
}