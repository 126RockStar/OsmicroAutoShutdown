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
using OsmicroAutoShutdown.Model;

namespace OsmicroAutoShutdown.SubForm
{
    public partial class MessageNoticeShow : Form
    {
        private MainForm mainForm;
        private DateTime _setTime;
        private readonly int SHUTDOWN_STATE = 0;

        public MessageNoticeShow()
        {
            InitializeComponent();
            InitUI();            
        }

        public MessageNoticeShow( MainForm mainform )
        {
            InitializeComponent();
            this.mainForm = mainform;
            InitUI();
            
        }

        private void InitUI()
        {
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;

            info_label.Parent = pictureBox1;
            info_label.BackColor = System.Drawing.Color.Transparent;

            delay_combobox.Items.Add("10 minutes");
            delay_combobox.Items.Add("30 minutes");
            delay_combobox.Items.Add("1 hours");
            delay_combobox.Items.Add("4 hours");
            delay_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            delay_combobox.SelectedIndex = 0;

            _setTime = this.mainForm._setTime;
            delay_timer.Start();
        }

        private void ShowMainForm()
        {
            this.mainForm.Show();
            this.mainForm.WindowState = FormWindowState.Normal;
        }       

        private void ShowInfoLabel(TimeSpan time)
        {           
            info_label.Text = "Your computer will " + ScheduleStore.operation +
                            " after " + time.Minutes + "m " + time.Seconds + "s.";
           
        }

        private void Delay_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ScheduleStore.scheduleType == ScheduleType.OnIdle)
                {
                    var set_idle_total_second = ScheduleStore.hour * 60 * 60 + ScheduleStore.minute * 60;
                    var remaining = set_idle_total_second - ((int)GetSystemIdleTime.GetIdleTime()) / 1000;
                    TimeSpan time = TimeSpan.FromSeconds(remaining);
                    ShowInfoLabel(time);
                    
                    if (((int)remaining) == SHUTDOWN_STATE)
                    {
                        this.mainForm.SetEndShutDown();
                        delay_timer.Stop();
                        this.mainForm.ExecuteCommand();
                        //MessageBox.Show("Shutdown");
                        this.Close();
                    }
                }
                else
                {
                    var now = DateTime.Now;
                    TimeSpan remaining = _setTime - now;
                    ShowInfoLabel(remaining);

                    if (((int)remaining.TotalSeconds) == SHUTDOWN_STATE)
                    {
                        if (ScheduleStore.scheduleType == ScheduleType.Daily)
                        {
                            this.mainForm.SetTimeAgainDaily();
                        }
                        else
                        {
                            this.mainForm.SetEndShutDown();
                        }
                        delay_timer.Stop();
                        this.mainForm.ExecuteCommand();
                        //MessageBox.Show("Shutdown");
                        this.Close();
                    }
                }
                
            }
            catch
            {

            }
        }
        private void Notice_exit_btn_Click(object sender, EventArgs e)
        {
            delay_timer.Stop();
            mainForm.ReceiveMessageNoticeOk();
            ShowMainForm();
            this.Close();
        }

        private void Notice_cancel_btn_Click(object sender, EventArgs e)
        {
            delay_timer.Stop();
            mainForm.ReceiveMessageNoticeCancel();
            ShowMainForm();
            this.Close();
        }

        private void Notice_ok_btn_Click(object sender, EventArgs e)
        {
            delay_timer.Stop();
            mainForm.ReceiveMessageNoticeOk();
            ShowMainForm();
            this.Close();
        }

        private void Notice_delay_alret_btn_Click(object sender, EventArgs e)
        {
            delay_timer.Stop();
            // doing
            ScheduleStore.ReadStore();

            if (ScheduleStore.scheduleType == ScheduleType.OnIdle)
            {
                var set_idle_total_second = ScheduleStore.hour * 60 * 60 + ScheduleStore.minute * 60;
                TimeSpan time = TimeSpan.FromSeconds(set_idle_total_second);
                DateTime changeSetTime = new DateTime().Add(time);
                DateTime changeTime = new DateTime();
                if (delay_combobox.SelectedIndex == 0)
                {
                    changeTime = changeSetTime.AddMinutes(10);
                }
                if (delay_combobox.SelectedIndex == 1)
                {
                    changeTime = changeSetTime.AddMinutes(30);
                }
                if (delay_combobox.SelectedIndex == 2)
                {
                    changeTime = changeSetTime.AddHours(1);
                }
                if (delay_combobox.SelectedIndex == 3)
                {
                    changeTime = changeSetTime.AddHours(4);
                }

                ScheduleStore.setdate = changeTime.ToString("yyyy-MM-dd-HH-mm-ss");
                ScheduleStore.hour = changeTime.Hour;
                ScheduleStore.minute = changeTime.Minute;
                ScheduleStore.WriteStore();
            }
            else
            {
                DateTime changeSetTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
                DateTime changeTime = new DateTime();
                if (delay_combobox.SelectedIndex == 0)
                {
                    changeTime = changeSetTime.AddMinutes(10);
                }
                if (delay_combobox.SelectedIndex == 1)
                {
                    changeTime = changeSetTime.AddMinutes(30);
                }
                if (delay_combobox.SelectedIndex == 2)
                {
                    changeTime = changeSetTime.AddHours(1);
                }
                if (delay_combobox.SelectedIndex == 3)
                {
                    changeTime = changeSetTime.AddHours(4);
                }

                ScheduleStore.setdate = changeTime.ToString("yyyy-MM-dd-HH-mm-ss");
                ScheduleStore.WriteStore();

            }

            mainForm.ReceiveMessageNoticeDelay();
            ShowMainForm();

            this.Close();
        }
    }
}
