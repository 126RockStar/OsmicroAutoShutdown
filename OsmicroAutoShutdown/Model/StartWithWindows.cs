using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;

namespace OsmicroAutoShutdown.Model
{
    public static class StartWithWindows
    {
        public static readonly string _execPath;
        private static RegistryKey rkApp_user = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private static RegistryKey rkApp_32 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private static RegistryKey rkApp_64 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private const string _regKey = "OsmicroAutoShutdown";

        static StartWithWindows()
        {
            _execPath = Assembly.GetExecutingAssembly().Location + " /winstart";
        }

        public static void Set(bool startWithWindows)
        {
            if(Environment.Is64BitOperatingSystem)
            {
                if (startWithWindows)
                {
                    rkApp_64.SetValue(_regKey, Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp_64.DeleteValue(_regKey, false);
                }
            }
            else
            {
                if (startWithWindows)
                {
                    rkApp_32.SetValue(_regKey, Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp_32.DeleteValue(_regKey, false);
                }
            }            
        }

        public static bool IsSet()
        {
            if( Environment.Is64BitOperatingSystem)
            {
                return rkApp_64.GetValue(_regKey) != null;
            }
            else
            {
                return rkApp_32.GetValue(_regKey) != null;
            }
            
        }
    }
}
