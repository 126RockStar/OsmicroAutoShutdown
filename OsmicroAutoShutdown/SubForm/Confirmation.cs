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
    public partial class Confirmation : Form
    {
        private MainForm _mainform;

        public Confirmation()
        {
            InitializeComponent();

            panel1.Parent = pictureBox1;
            panel1.BackColor = System.Drawing.Color.Transparent;
        }

        public Confirmation( MainForm mainform)
        {
            InitializeComponent();

            panel1.Parent = pictureBox1;
            panel1.BackColor = System.Drawing.Color.Transparent;

            _mainform = mainform;
        }

        private void Confirm_exit_btn_Click(object sender, EventArgs e)
        {
            _mainform.confirm_yes = false;
            this.Close();
        }

        private void Confirm_no_btn_Click(object sender, EventArgs e)
        {
            _mainform.confirm_yes = false;
            this.Close();
        }

        private void Confirm_yes_Click(object sender, EventArgs e)
        {
            _mainform.confirm_yes = true;
            this.Close();
        }
    }
}
