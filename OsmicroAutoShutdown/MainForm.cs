using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OsmicroAutoShutdown.Model;
using OsmicroAutoShutdown.SubForm;
using OsmicroAutoShutdown.Data;
using System.Timers;
using System.Management;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using OsmicroAutoShutdown.Model.SingleInstance;

namespace OsmicroAutoShutdown
{
    public partial class MainForm : Form
    {
        public DateTime _setTime; // fs,now,daily
        private int DelayMinutes = 5;
        private readonly int SHUTDOWN_STATE = 0;
        public bool confirm_yes;

        private bool allowVisible = true;     // ContextMenu's Show command used
        private bool allowClose = true;         //SetVisibleCore(), OnFormClosing()

        public MainForm()
        {
            
            if (LogInStart.SignIntime() < 20)
            {
                allowVisible = false;
                allowClose = false;
            }
            

            InitializeComponent();

            StartWithWindows.Set(true); // this function is start with running operating system.
            
            InitUI();            
            
            ScheduleStore.ReadStore();  // Read ScheduleDB

            if (!ScheduleStore.doingSchedule)
            {
                InitComponentEnable();
            }
            else
            {                
                ScheduleStoreInitComponent();
                StartShutDown();
            }
           
        }
        
        
        /* ============================== GUI Controll ================================*/

        private void InitUI()
        {
            /* ---background transparent */
            title_panel.Parent = background_picturbox;
            title_panel.BackColor = System.Drawing.Color.Transparent;

            bottom_panel.Parent = background_picturbox;
            bottom_panel.BackColor = System.Drawing.Color.Transparent;

            select_task_label.Parent = background_picturbox;
            select_task_label.BackColor = System.Drawing.Color.Transparent;

            time_label.Parent = background_picturbox;
            time_label.BackColor = System.Drawing.Color.Transparent;

            time_zone_label.Parent = background_picturbox;
            time_zone_label.BackColor = System.Drawing.Color.Transparent;

            title_label.ForeColor = Color.FromArgb(255, 255, 255);

            SetLabelTimer();

            notifyIcon1.Text = "Osmicro Auto Shutdown";
        }

        private void InitComponentEnable()
        {
            /* datetimepicker init disable */
            st_date_picker.Enabled = true;
            st_time_picker.Enabled = true;

            fn_hour_picker.Enabled = false;
            fn_minute_picker.Enabled = false;

            da_time_picker.Enabled = false;

            oi_hour_picker.Enabled = false;
            oi_minute_picker.Enabled = false;

            if (ScheduleStore.MessageNoticeShow)
            {
                remind_checkbox.Checked = true;
            }
            else
            {
                remind_checkbox.Checked = false;
            }

            DateTime targetTime = new DateTime(
                    Convert.ToInt16(st_date_picker.Value.ToString("yyyy")),
                    Convert.ToInt16(st_date_picker.Value.ToString("MM")),
                    Convert.ToInt16(st_date_picker.Value.ToString("dd")),
                    Convert.ToInt16(st_time_picker.Value.ToString("HH")),
                    Convert.ToInt16(st_time_picker.Value.ToString("mm")),
                    Convert.ToInt16(st_time_picker.Value.ToString("ss"))
                    );

            LikInfoLabelLayout1("Shut down", targetTime.ToString("h:mm:ss tt MM/dd/yyyy"));
        }

        private void ScheduleStoreInitComponent()
        {
            ScheduleStore.ReadStore();
            // Operation set

            if (ScheduleStore.operation == ShutDownOperation.ShutDown)
            {
                shutdown_radio.Checked = true;                
            }

            if (ScheduleStore.operation == ShutDownOperation.Restart)
            {
                restart_radio.Checked = true;                
            }

            if (ScheduleStore.operation == ShutDownOperation.SignOut)
            {
                Log_off_radio.Checked = true;
            }

            if( ScheduleStore.MessageNoticeShow)
            {
                remind_checkbox.Checked = true;
            }
            else
            {
                remind_checkbox.Checked = false;
            }
            
            // scheduleType Set
            if( ScheduleStore.scheduleType == ScheduleType.SpecifyTime)
            {
                DateTime setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
                LikInfoLabelLayout1(ScheduleStore.operation.ToString(), setTime.ToString("h:mm:ss tt MM/dd/yyyy"));

                specify_time_radio.Checked = true;
                st_date_picker.Value = DateTime.Parse(ScheduleStore.date);
                st_time_picker.Value = new DateTime(2000, 1, 26, ScheduleStore.hour, ScheduleStore.minute, ScheduleStore.second);
            }
            if (ScheduleStore.scheduleType == ScheduleType.FromNow)
            {                
                LikInfoLabelLayout2(ScheduleStore.operation.ToString(), ScheduleStore.hour.ToString(), ScheduleStore.minute.ToString());

                from_now_radio.Checked = true;
                fn_hour_picker.Value = new DateTime(2000, 1, 26, ScheduleStore.hour, 26, 26);
                fn_minute_picker.Value = new DateTime(2000, 1, 26, 1, ScheduleStore.minute, 26);
            }
            if (ScheduleStore.scheduleType == ScheduleType.Daily)
            {
                DateTime setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
                LikInfoLabelLayout3(ScheduleStore.operation.ToString(), setTime.ToString("h:mm:ss tt"));

                daily_radio.Checked = true;
                da_time_picker.Value = new DateTime(2000, 1, 26, ScheduleStore.hour, ScheduleStore.minute, ScheduleStore.second);
            }
            if (ScheduleStore.scheduleType == ScheduleType.OnIdle)
            {
                LikInfoLabelLayout4(ScheduleStore.operation.ToString(), ScheduleStore.hour.ToString(), ScheduleStore.minute.ToString());

                on_idle_radio.Checked = true;
                oi_hour_picker.Value = new DateTime(2000, 1, 26, ScheduleStore.hour, 26, 26);
                oi_minute_picker.Value = new DateTime(2000, 1, 26, 1, ScheduleStore.minute, 26);
            }
            AllComponentDisable();

            start_task_btn.Image = Properties.Resources.cancel_task_btn_normal;
            start_task_btn.ActiveImage = Properties.Resources.cancel_task_btn_over;
            start_task_btn.Refresh();
        }

        private void AllComponentEnable()
        {
            shutdown_radio.Enabled = true;
            restart_radio.Enabled = true;
            Log_off_radio.Enabled = true;
            remind_checkbox.Enabled = true;

            specify_time_radio.Enabled = true;
            from_now_radio.Enabled = true;
            daily_radio.Enabled = true;
            on_idle_radio.Enabled = true;

            if (specify_time_radio.Checked)
            {
                DateTimePickersSet("st");
            }

            if (from_now_radio.Checked)
            {
                DateTimePickersSet("fn");
            }

            if (daily_radio.Checked)
            {
                DateTimePickersSet("da");
            }

            if (on_idle_radio.Checked)
            {
                DateTimePickersSet("oi");
            }

        }

        private void AllComponentDisable()
        {
            shutdown_radio.Enabled = false;
            restart_radio.Enabled = false;
            Log_off_radio.Enabled = false;
            remind_checkbox.Enabled = false;

            specify_time_radio.Enabled = false;
            from_now_radio.Enabled = false;
            daily_radio.Enabled = false;
            on_idle_radio.Enabled = false;

            st_date_picker.Enabled = false;
            st_time_picker.Enabled = false;

            fn_hour_picker.Enabled = false;
            fn_minute_picker.Enabled = false;

            da_time_picker.Enabled = false;

            oi_hour_picker.Enabled = false;
            oi_minute_picker.Enabled = false;

            from_now_right_label.ForeColor = Color.FromArgb(171, 171, 171);
        }

        private void DateTimePickersSet( string state)
        {
            if( state == "st")
            {
                from_now_right_label.Visible = false;

                st_date_picker.Enabled = true;
                st_time_picker.Enabled = true;

                fn_hour_picker.Enabled = false;
                fn_minute_picker.Enabled = false;

                da_time_picker.Enabled = false;

                oi_hour_picker.Enabled = false;
                oi_minute_picker.Enabled = false;
            }

            if (state == "fn")
            {
                from_now_right_label.Visible = true;

                st_date_picker.Enabled = false;
                st_time_picker.Enabled = false;

                fn_hour_picker.Enabled = true;
                fn_minute_picker.Enabled = true;

                da_time_picker.Enabled = false;

                oi_hour_picker.Enabled = false;
                oi_minute_picker.Enabled = false;
            }

            if (state == "da")
            {
                from_now_right_label.Visible = false;

                st_date_picker.Enabled = false;
                st_time_picker.Enabled = false;

                fn_hour_picker.Enabled = false;
                fn_minute_picker.Enabled = false;

                da_time_picker.Enabled = true;

                oi_hour_picker.Enabled = false;
                oi_minute_picker.Enabled = false;
            }

            if (state == "oi")
            {
                from_now_right_label.Visible = false;

                st_date_picker.Enabled = false;
                st_time_picker.Enabled = false;

                fn_hour_picker.Enabled = false;
                fn_minute_picker.Enabled = false;

                da_time_picker.Enabled = false;

                oi_hour_picker.Enabled = true;
                oi_minute_picker.Enabled = true;
            }
        }

        private void PutScheduleStoreComponentState()
        {
            // Shutdown operation Set
            ScheduleStore.ReadStore();
            if(shutdown_radio.Checked)
            {
                ScheduleStore.operation = ShutDownOperation.ShutDown;
            }
            if (restart_radio.Checked)
            {
                ScheduleStore.operation = ShutDownOperation.Restart;
            }
            if (Log_off_radio.Checked)
            {
                ScheduleStore.operation = ShutDownOperation.SignOut;
            }


            // Schdule Set

            if (specify_time_radio.Checked)
            {
                ScheduleStore.scheduleType = ScheduleType.SpecifyTime;
                ScheduleStore.date = st_date_picker.Value.ToString("yyyy-MM-dd"); 
                ScheduleStore.hour = Convert.ToInt16(st_time_picker.Value.ToString("HH"));
                ScheduleStore.minute = Convert.ToInt16(st_time_picker.Value.ToString("mm"));
                ScheduleStore.second = Convert.ToInt16(st_time_picker.Value.ToString("ss"));

                DateTime targetTime = new DateTime(
                    Convert.ToInt16(st_date_picker.Value.ToString("yyyy")),
                    Convert.ToInt16(st_date_picker.Value.ToString("MM")),
                    Convert.ToInt16(st_date_picker.Value.ToString("dd")),
                    Convert.ToInt16(st_time_picker.Value.ToString("HH")),
                    Convert.ToInt16(st_time_picker.Value.ToString("mm")),
                    Convert.ToInt16(st_time_picker.Value.ToString("ss"))
                    );

                ScheduleStore.setdate = targetTime.ToString("yyyy-MM-dd-HH-mm-ss");
            }
            if (from_now_radio.Checked)
            {
                ScheduleStore.scheduleType = ScheduleType.FromNow;
                ScheduleStore.hour = Convert.ToInt16(fn_hour_picker.Value.ToString("HH"));
                ScheduleStore.minute = Convert.ToInt16(fn_minute_picker.Value.ToString("mm"));

                DateTime targetTime = DateTime.Now.AddHours(Convert.ToInt16(fn_hour_picker.Value.ToString("HH")))
                                                  .AddMinutes(Convert.ToInt16(fn_minute_picker.Value.ToString("mm")));
                ScheduleStore.setdate = targetTime.ToString("yyyy-MM-dd-HH-mm-ss");
            }
            if (daily_radio.Checked)
            {
                ScheduleStore.scheduleType = ScheduleType.Daily;
                ScheduleStore.hour = Convert.ToInt16(da_time_picker.Value.ToString("HH"));
                ScheduleStore.minute = Convert.ToInt16(da_time_picker.Value.ToString("mm"));
                ScheduleStore.second = Convert.ToInt16(da_time_picker.Value.ToString("ss"));

                DateTime targetTime = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    Convert.ToInt16(da_time_picker.Value.ToString("HH")),
                    Convert.ToInt16(da_time_picker.Value.ToString("mm")),
                    Convert.ToInt16(da_time_picker.Value.ToString("ss"))
                    );
                ScheduleStore.setdate = targetTime.ToString("yyyy-MM-dd-HH-mm-ss");
            }
            if (on_idle_radio.Checked)
            {
                ScheduleStore.scheduleType = ScheduleType.OnIdle;
                ScheduleStore.hour = Convert.ToInt16(oi_hour_picker.Value.ToString("HH"));
                ScheduleStore.minute = Convert.ToInt16(oi_minute_picker.Value.ToString("mm"));                
            }
        }

        private void ShowInfoLabel()
        {
            string result = "";
            if (shutdown_radio.Checked)
            {
                result = ShutDownOperation.ShutDown.ToString();
            }
            if (restart_radio.Checked)
            {
                result = ShutDownOperation.Restart.ToString();
            }
            if (Log_off_radio.Checked)
            {
                result = ShutDownOperation.SignOut.ToString();
            }


            // Schdule Set

            if (specify_time_radio.Checked)
            {
                DateTime targetTime = new DateTime(
                    Convert.ToInt16(st_date_picker.Value.ToString("yyyy")),
                    Convert.ToInt16(st_date_picker.Value.ToString("MM")),
                    Convert.ToInt16(st_date_picker.Value.ToString("dd")),
                    Convert.ToInt16(st_time_picker.Value.ToString("HH")),
                    Convert.ToInt16(st_time_picker.Value.ToString("mm")),
                    Convert.ToInt16(st_time_picker.Value.ToString("ss"))
                    );

                LikInfoLabelLayout1(result, targetTime.ToString("h:mm:ss tt MM/dd/yyyy"));
            }
            if (from_now_radio.Checked)
            {
                LikInfoLabelLayout2(result, Convert.ToInt16(fn_hour_picker.Value.ToString("HH")).ToString(), Convert.ToInt16(fn_minute_picker.Value.ToString("mm")).ToString());
            }
            if (daily_radio.Checked)
            {
                DateTime targetTime = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    Convert.ToInt16(da_time_picker.Value.ToString("HH")),
                    Convert.ToInt16(da_time_picker.Value.ToString("mm")),
                    Convert.ToInt16(da_time_picker.Value.ToString("ss"))
                    );
                LikInfoLabelLayout3(result, targetTime.ToString("h:mm:ss tt"));
            }
            if (on_idle_radio.Checked)
            {
                LikInfoLabelLayout4(result, Convert.ToInt16(oi_hour_picker.Value.ToString("HH")).ToString(), Convert.ToInt16(oi_minute_picker.Value.ToString("mm")).ToString());
            }
        }

        private bool CheckTimeZone()
        {
            if( specify_time_radio.Checked )
            {
                DateTime checkDateTime = new DateTime();

                if (specify_time_radio.Checked)
                {
                    ScheduleStore.scheduleType = ScheduleType.SpecifyTime;
                    ScheduleStore.date = st_date_picker.Value.ToString("yyyy-MM-dd");
                    ScheduleStore.hour = Convert.ToInt16(st_time_picker.Value.ToString("HH"));
                    ScheduleStore.minute = Convert.ToInt16(st_time_picker.Value.ToString("mm"));
                    ScheduleStore.second = Convert.ToInt16(st_time_picker.Value.ToString("ss"));

                    checkDateTime = new DateTime(
                        Convert.ToInt16(st_date_picker.Value.ToString("yyyy")),
                        Convert.ToInt16(st_date_picker.Value.ToString("MM")),
                        Convert.ToInt16(st_date_picker.Value.ToString("dd")),
                        Convert.ToInt16(st_time_picker.Value.ToString("HH")),
                        Convert.ToInt16(st_time_picker.Value.ToString("mm")),
                        Convert.ToInt16(st_time_picker.Value.ToString("ss"))
                        );

                }

                var now = DateTime.Now;
                TimeSpan remaining = checkDateTime - now;

                if (remaining.TotalSeconds <= SHUTDOWN_STATE)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.ShowDialog();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            
        }

        private void LikInfoLabelLayout1( string one, string two )
        {
            if(one == ShutDownOperation.ShutDown.ToString())
            {
                r_in_la_1.Text = "Shut down";
            }
            else if(one == ShutDownOperation.SignOut.ToString())
            {
                r_in_la_1.Text = "Sign out";
            }
            else
            {
                r_in_la_1.Text = one;
            }
            
            r_in_la_2.Text = two;
            r_in_la_3.Text = "";

            in_la_2.Text = "at";
            in_la_3.Text = "";
            in_la_4.Text = "";
            // [i_1] {r_1} [i_2] {r_2} [i_3]
            r_in_la_1.Location = new Point((in_la_1.Location.X + in_la_1.Size.Width-5), (in_la_1.Location.Y-3));
            in_la_2.Location = new Point((r_in_la_1.Location.X+r_in_la_1.Size.Width-3), in_la_1.Location.Y);
            r_in_la_2.Location = new Point((in_la_2.Location.X + in_la_2.Size.Width-5), (in_la_1.Location.Y - 3));
            in_la_3.Location = new Point((r_in_la_2.Location.X + r_in_la_2.Size.Width-3), in_la_1.Location.Y);
            r_in_la_3.Location = new Point((in_la_3.Location.X + in_la_3.Size.Width-5), (in_la_1.Location.Y - 3));
            in_la_4.Location = new Point((r_in_la_3.Location.X + r_in_la_3.Size.Width-5), in_la_1.Location.Y);
        }
        private void LikInfoLabelLayout2( string one, string two, string three )
        {
            if (one == ShutDownOperation.ShutDown.ToString())
            {
                r_in_la_1.Text = "Shut down";
            }
            else if (one == ShutDownOperation.SignOut.ToString())
            {
                r_in_la_1.Text = "Sign out";
            }
            else
            {
                r_in_la_1.Text = one;
            }
            r_in_la_2.Text = two;
            r_in_la_3.Text = three;

            in_la_2.Text = "in";
            in_la_3.Text = "hour(s) and ";
            in_la_4.Text = "minute(s).";
            // [i_1] {r_1} [i_2] {r_2} [i_3]
            r_in_la_1.Location = new Point((in_la_1.Location.X + in_la_1.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_2.Location = new Point((r_in_la_1.Location.X + r_in_la_1.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_2.Location = new Point((in_la_2.Location.X + in_la_2.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_3.Location = new Point((r_in_la_2.Location.X + r_in_la_2.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_3.Location = new Point((in_la_3.Location.X + in_la_3.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_4.Location = new Point((r_in_la_3.Location.X + r_in_la_3.Size.Width - 3), in_la_1.Location.Y);
        }
        private void LikInfoLabelLayout3( string one, string two )
        {
            if (one == ShutDownOperation.ShutDown.ToString())
            {
                r_in_la_1.Text = "Shut down";
            }
            else if (one == ShutDownOperation.SignOut.ToString())
            {
                r_in_la_1.Text = "Sign out";
            }
            else
            {
                r_in_la_1.Text = one;
            }
            r_in_la_2.Text = two;
            r_in_la_3.Text = "";

            in_la_2.Text = "at";
            in_la_3.Text = "every day.";
            in_la_4.Text = "";
            // [i_1] {r_1} [i_2] {r_2} [i_3]
            r_in_la_1.Location = new Point((in_la_1.Location.X + in_la_1.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_2.Location = new Point((r_in_la_1.Location.X + r_in_la_1.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_2.Location = new Point((in_la_2.Location.X + in_la_2.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_3.Location = new Point((r_in_la_2.Location.X + r_in_la_2.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_3.Location = new Point((in_la_3.Location.X + in_la_3.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_4.Location = new Point((r_in_la_3.Location.X + r_in_la_3.Size.Width - 3), in_la_1.Location.Y);
        }
        private void LikInfoLabelLayout4( string one, string two, string three )
        {
            if (one == ShutDownOperation.ShutDown.ToString())
            {
                r_in_la_1.Text = "Shut down";
            }
            else if (one == ShutDownOperation.SignOut.ToString())
            {
                r_in_la_1.Text = "Sign out";
            }
            else
            {
                r_in_la_1.Text = one;
            }
            r_in_la_2.Text = two;
            r_in_la_3.Text = three;

            in_la_2.Text = "in";
            in_la_3.Text = "hour(s) and";
            in_la_4.Text = "minute(s) in idle.";
            // [i_1] {r_1} [i_2] {r_2} [i_3]
            r_in_la_1.Location = new Point((in_la_1.Location.X + in_la_1.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_2.Location = new Point((r_in_la_1.Location.X + r_in_la_1.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_2.Location = new Point((in_la_2.Location.X + in_la_2.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_3.Location = new Point((r_in_la_2.Location.X + r_in_la_2.Size.Width - 3), in_la_1.Location.Y);
            r_in_la_3.Location = new Point((in_la_3.Location.X + in_la_3.Size.Width - 5), (in_la_1.Location.Y - 3));
            in_la_4.Location = new Point((r_in_la_3.Location.X + r_in_la_3.Size.Width - 3), in_la_1.Location.Y);
        }
        /* ============================== Timer Controll ============================== */
        // lable_timer_set

        private void SetLabelTimer()
        {
            label_timer.Interval = 1000; // 1s
            label_timer.Start();

            from_now_right_label.Text = "(" + DateTime.Now.ToString() + ")";
        }        
        private void Label_timer_Tick(object sender, EventArgs e)
        {
            time_zone_label.Text = DateTime.Now.ToString();
            //test_label.Text = Convert.ToString(GetSystemIdleTime.GetIdleTime());
            if (ScheduleStore.doingSchedule)
            {
                from_now_right_label.Text = "(" + DateTime.Now.ToString() + ")";
                
            }
        }

        // shutdown_timer_set -> interval 100

        private void StartShutDown()
        {
            //_setTime = DateTime.Now;
            GetSetTime();
            shutdown_timer.Start();
        }

        private void StopShutDown()
        {            
            shutdown_timer.Stop();
        }

        private void GetSetTime()
        {
            ScheduleStore.ReadStore();
            _setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
        }

        public void SetTimeAgainDaily()
        {
            ScheduleStore.ReadStore();
            DateTime setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
            DateTime changeTime = setTime.AddDays(1);
            ScheduleStore.setdate = changeTime.ToString("yyyy-MM-dd-HH-mm-ss");
            ScheduleStore.doingSchedule = true;
            ScheduleStore.WriteStore();
        }

        public void SetEndShutDown()
        {
            ScheduleStore.ReadStore();
            ScheduleStore.doingSchedule = false;
            ScheduleStore.WriteStore();

            start_task_btn.Image = Properties.Resources.start_task_btn_normal;
            start_task_btn.ActiveImage = Properties.Resources.start_task_btn_over;
            start_task_btn.Refresh();

            AllComponentEnable();
            StopShutDown();
        }

        //receive messageNotice
        public void ReceiveMessageNoticeOk()
        {
            StartShutDown();
        }

        public void ReceiveMessageNoticeDelay()
        {
            StartShutDown();
        }

        public void ReceiveMessageNoticeCancel()
        {
            ScheduleStore.ReadStore();            
            ScheduleStore.doingSchedule = false;
            ScheduleStore.WriteStore();

            start_task_btn.Image = Properties.Resources.start_task_btn_normal;
            start_task_btn.ActiveImage = Properties.Resources.start_task_btn_over;
            start_task_btn.Refresh();

            AllComponentEnable();
            StopShutDown();
        }


        private void ShowInfoLabel(TimeSpan timeSpan)
        {
            if (ScheduleStore.scheduleType == ScheduleType.SpecifyTime)
            {
                DateTime setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
                LikInfoLabelLayout1(ScheduleStore.operation.ToString(), setTime.ToString("h:mm:ss tt MM/dd/yyyy"));
            }
            if (ScheduleStore.scheduleType == ScheduleType.FromNow)
            {
                LikInfoLabelLayout2(ScheduleStore.operation.ToString(), timeSpan.Hours.ToString(), timeSpan.Minutes.ToString());
            }
            if (ScheduleStore.scheduleType == ScheduleType.Daily)
            {
                DateTime setTime = DateTime.ParseExact(ScheduleStore.setdate, "yyyy-MM-dd-HH-mm-ss", null);
                LikInfoLabelLayout3(ScheduleStore.operation.ToString(), setTime.ToString("h:mm:ss tt"));
            }
            if (ScheduleStore.scheduleType == ScheduleType.OnIdle)
            {
                LikInfoLabelLayout4(ScheduleStore.operation.ToString(), timeSpan.Hours.ToString(), timeSpan.Minutes.ToString());
            }
        }

        public void ExecuteCommand()
        {

            if (ScheduleStore.operation == ShutDownOperation.ShutDown)
            {
                ShutDownOperationMethods.Shut();
            }
            if (ScheduleStore.operation == ShutDownOperation.Restart)
            {
                ShutDownOperationMethods.Restart();
            }
            if (ScheduleStore.operation == ShutDownOperation.SignOut)
            {
                ShutDownOperationMethods.SignOut();
            }
        }

        private void Shutdown_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if(ScheduleStore.scheduleType == ScheduleType.OnIdle)
                {
                    var set_idle_total_second = ScheduleStore.hour * 60 * 60 + ScheduleStore.minute * 60;
                    var remaining = set_idle_total_second - ((int)GetSystemIdleTime.GetIdleTime())/1000;
                    TimeSpan time = TimeSpan.FromSeconds(remaining);                    
                    ShowInfoLabel(time);
                    test_label.Text = "" + Convert.ToString(remaining) + "";

                    if (ScheduleStore.MessageNoticeShow)
                    {
                        if (((int)remaining) == DelayMinutes * 60)
                        //if (((int)remaining) == 50)
                        {
                            this.shutdown_timer.Stop();
                            MessageNoticeShow messageNoticeShow = new MessageNoticeShow(this);
                            messageNoticeShow.ShowDialog();
                        }
                    }

                    if (((int)remaining) == SHUTDOWN_STATE)
                    {                        
                        SetEndShutDown();                        
                        shutdown_timer.Stop();
                        ExecuteCommand();
                        //MessageBox.Show("Shutdown");
                    }
                }
                else
                {
                    var now = DateTime.Now;
                    TimeSpan remaining = _setTime - now;
                    ShowInfoLabel(remaining);
                    test_label.Text = Convert.ToString(remaining.TotalSeconds) + ": notice " + ScheduleStore.MessageNoticeShow + "";
                   
                    if (ScheduleStore.MessageNoticeShow)
                    {
                        if (((int)remaining.TotalSeconds) == DelayMinutes * 60)
                            //if (((int)remaining.TotalSeconds) == 50)
                        {
                            this.shutdown_timer.Stop();
                            MessageNoticeShow messageNoticeShow = new MessageNoticeShow(this);
                            messageNoticeShow.ShowDialog();

                        }
                    }

                    if (((int)remaining.TotalSeconds) == SHUTDOWN_STATE)
                    {
                        if (ScheduleStore.scheduleType == ScheduleType.Daily)
                        {
                            SetTimeAgainDaily();
                        }
                        else
                        {
                            SetEndShutDown();
                        }
                        shutdown_timer.Stop();
                        ExecuteCommand();
                        //MessageBox.Show("Shutdown");
                    }
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /* ===========================Controlls Events =================================*/

        private void Remind_checkbox_MouseHover(object sender, EventArgs e)
        {
            remind_checkbox.ForeColor = Color.FromArgb(0, 122, 204);
        }

        private void Remind_checkbox_MouseLeave(object sender, EventArgs e)
        {
            remind_checkbox.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void Specify_time_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickersSet("st");
            ShowInfoLabel();
        }

        private void From_now_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickersSet("fn");
            ShowInfoLabel();
        }

        private void Daily_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickersSet("da");
            ShowInfoLabel();
        }

        private void On_idle_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickersSet("oi");
            ShowInfoLabel();
        }

        private void title_label_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {   

            ScheduleStore.ReadStore();
            if (ScheduleStore.doingSchedule)
            {
                this.WindowState = FormWindowState.Minimized;
                Hide();
            }
            else
            {
                allowClose = true;
                System.Windows.Forms.Application.Exit();
            }
            
        }

        private void Minize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void Start_task_btn_Click(object sender, EventArgs e)
        {
            
                     
        }

        private void start_task_btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CheckTimeZone())
                return;

            ScheduleStore.ReadStore();

            if (ScheduleStore.doingSchedule)
            {
                Confirmation confirmation = new Confirmation(this);
                confirmation.ShowDialog();
                
                if( confirm_yes)
                {
                    ScheduleStore.doingSchedule = false;
                    ScheduleStore.WriteStore();
                    start_task_btn.Image = Properties.Resources.start_task_btn_normal;
                    start_task_btn.ActiveImage = Properties.Resources.start_task_btn_over;
                    start_task_btn.Refresh();

                    AllComponentEnable();
                    StopShutDown();

                }
                
            }
            else
            {
                if (ScheduleStore.MessageTrayShow)
                {
                    MessageTrayShow messageTrayShow = new MessageTrayShow(this);
                    messageTrayShow.ShowDialog();
                }

                PutScheduleStoreComponentState();
                ScheduleStore.doingSchedule = true;
                ScheduleStore.WriteStore();
                start_task_btn.Image = Properties.Resources.cancel_task_btn_normal;
                start_task_btn.ActiveImage = Properties.Resources.cancel_task_btn_over;
                start_task_btn.Refresh();

                AllComponentDisable();
                StartShutDown();

                this.WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }                
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left) {
                allowVisible = true;
                Show();
                WindowState = FormWindowState.Normal;
            }            
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Exit");
            allowClose = true;
            ReceiveMessageNoticeCancel();
            System.Windows.Forms.Application.Exit();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ReceiveMessageNoticeCancel();
            ShutDownOperationMethods.Shut();
            //MessageBox.Show("Shut down PC Now");
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReceiveMessageNoticeCancel();
            ShutDownOperationMethods.Restart();
            //MessageBox.Show("Restart PC Now");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Show Main Interface");
            allowVisible = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        /* when start directly tray icon (init variable in init function ) */
        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }


        private void remind_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if( remind_checkbox.Checked)
            {
                ScheduleStore.ReadStore();
                ScheduleStore.MessageNoticeShow = true;
                ScheduleStore.WriteStore();
            }
            else
            {
                ScheduleStore.ReadStore();
                ScheduleStore.MessageNoticeShow = false;
                ScheduleStore.WriteStore();
            }
        }

        private void shutdown_radio_CheckedChanged(object sender, EventArgs e)
        {
            ShowInfoLabel();
        }

        private void restart_radio_CheckedChanged(object sender, EventArgs e)
        {
            ShowInfoLabel();
        }

        private void Log_off_radio_CheckedChanged(object sender, EventArgs e)
        {
            ShowInfoLabel();
        }

        private void Osmicro_brand_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://osmicro.com.au/about-osmicro/");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.
                    OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System",
                    Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue("ConsentPromptBehaviorAdmin", 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                allowVisible = true;
                allowClose = true;
                ShowWindow();
            }
            base.WndProc(ref message);
        }

        public void ShowWindow()
        {
            // Insert code here to make your form show itself.
            WinApi.ShowToFront(this.Handle);
        }
    }
}
