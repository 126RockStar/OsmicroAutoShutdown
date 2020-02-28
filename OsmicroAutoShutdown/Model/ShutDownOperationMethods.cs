using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmicroAutoShutdown.Model
{
    public enum ShutDownOperation
    {
        ShutDown,
        SignOut,
        Restart,
        Hibernate,
        Sleep
    }

    public enum ScheduleType
    {
        SpecifyTime,
        FromNow,
        Daily,
        OnIdle
    }
    public static class ShutDownOperationMethods
    {
        public static string GetOperationName(this ShutDownOperation op, bool force, bool useShortName = false)
        {
            string opName;
            switch (op)
            {
                case ShutDownOperation.Hibernate:
                    opName = useShortName ? "H" : "Hibernate";
                    break;
                case ShutDownOperation.Restart:
                    if (useShortName)
                        opName = force ? "F-R" : "R";
                    else
                        opName = force ? "Forced restart" : "Restart";
                    break;
                case ShutDownOperation.ShutDown:
                    if (useShortName)
                        opName = force ? "F-SD" : "SD";
                    else
                        opName = force ? "Forced shut down" : "Shut down";
                    break;
                case ShutDownOperation.SignOut:
                    opName = useShortName ? "LO" : "Log off";
                    break;
                case ShutDownOperation.Sleep:
                    opName = useShortName ? "S" : "Sleep";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return opName;
        }

        public static string GetCommandLineArgs(this ShutDownOperation operation, bool force)
        {
            string args;
            switch (operation)
            {
                case ShutDownOperation.Hibernate:
                    args = string.Empty;
                    break;
                case ShutDownOperation.Restart:
                    args = "-r";
                    break;
                case ShutDownOperation.ShutDown:
                    args = "-s";
                    break;
                case ShutDownOperation.SignOut:
                    args = "-l";
                    break;
                case ShutDownOperation.Sleep:
                    args = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!string.IsNullOrEmpty(args))
            {
                args += (force ? " -f" : string.Empty) + " -t 0";
            }

            return args;
        }

        public static void Restart()
        {
            StartShutDown("-f -r -t 5");
        }

        public static void SignOut()
        {
            StartShutDown("-l");
        }

        public static void Shut()
        {
            StartShutDown("-f -s -t 5");
        }

        private static void StartShutDown(string param)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown " + param;
            Process.Start(proc);
        }
    }
}
