using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OsmicroAutoShutdown.Data;

namespace OsmicroAutoShutdown.SubForm
{
    public partial class MessageTrayShow : Form
    {
        MainForm _parent;

        public MessageTrayShow( MainForm parent )
        {
            InitializeComponent();

            this._parent = parent;

            panel1.Parent = pictureBox1;
            panel1.BackColor = System.Drawing.Color.Transparent;
        }

        private void Tray_exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            this._parent.WindowState = FormWindowState.Minimized;
        }

        private void Tray_ok_btn_Click(object sender, EventArgs e)
        {
            if (prompt_checkbox.Checked)
            {
                ScheduleStore.MessageTrayShow = false;
            }
            ScheduleStore.WriteStore();

            this.Close();
            this._parent.WindowState = FormWindowState.Minimized;            
        }
    }
}
