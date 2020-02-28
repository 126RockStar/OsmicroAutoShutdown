using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OsmicroAutoShutdown.Model.SingleInstance;

namespace OsmicroAutoShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            AvoidUAC();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                MainForm mainForm = new MainForm();
                Application.Run(mainForm);
                //Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            SingleInstance.Stop();


            ///* if running task, show window */
            //bool onlyInstance = false;
            //Mutex mutex = new Mutex(true, "OsmicroAutoShutdown", out onlyInstance);
            //if (!onlyInstance)
            //{
            //    //ShowToFront("OsmicroAutoShutdown");
            //    //return;
            //}
            ////
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //AvoidUAC();
            //if ( SignIntime() < 60)
            //{
            //    MainForm myForm = new MainForm();
            //    Application.Run();
            //}
            //else
            //{
            //    Application.Run(new MainForm());
            //}
            //kill mutex
            //GC.KeepAlive(mutex);
        }


        public static void AvoidUAC()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.
                    OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System",
                    Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue("ConsentPromptBehaviorAdmin", 0);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
    }
}
