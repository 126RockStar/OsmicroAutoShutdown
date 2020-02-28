using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsmicroAutoShutdown.SubForm
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();

            panel1.Parent = pictureBox1;
            panel1.BackColor = System.Drawing.Color.Transparent;
        }

        private void Error_exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
