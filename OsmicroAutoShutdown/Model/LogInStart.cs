using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsmicroAutoShutdown.Model
{
    static public class LogInStart
    {

        public static int SignIntime()
        {
            
            string userName = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            string machineName = WindowsIdentity.GetCurrent().Name.Split('\\')[0];
            PrincipalContext c = new PrincipalContext(ContextType.Machine, machineName);
            UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
            DateTime? CurrentUserLoggedInTime = uc.LastLogon;

            var now = DateTime.Now;
            TimeSpan remaining = now - (DateTime)CurrentUserLoggedInTime;
            MessageBox.Show(((int)remaining.TotalSeconds).ToString());

            return (int)remaining.TotalSeconds;
        }
    }
}
