using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using OsmicroAutoShutdown.Model;

namespace OsmicroAutoShutdown.Data
{
    class ScheduleStore : DataBase
    {
        public static ScheduleStore Instance { get; private set; }

        private static readonly string _filePath;

        public static string setdate { get; set; }
        public static string date { get; set; }
        public static int hour { get; set; }
        public static int minute { get; set; }
        public static int second { get; set; }
        public static ShutDownOperation operation { get; set; }
        public static ScheduleType scheduleType { get; set; }
        public static bool doingSchedule { get; set; }
        public static bool CloseToTray { get; set; }
        public static bool MessageTrayShow { get; set; }
        public static bool MessageNoticeShow { get; set; }
        

        // C:\Users\Money\AppData\Roaming\ShutDown_Schedule\schedule
        static ScheduleStore()
        {
            _filePath = Path.Combine(FolderPath, "schedule");
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                if (!File.Exists(_filePath))
                {
                    DefaultSettings();
                    //def.Save();
                    //File.WriteAllText(_filePath, "asdfasdf");
                }
            }
            catch { }
            
        }

        public static void DefaultSettings()
        {
            setdate = "2019-01-01-00-00-00";
            date = "2019-01-01";
            hour = 0;
            minute = 6;
            second = 6;
            doingSchedule = false;
            CloseToTray = false;
            operation = ShutDownOperation.ShutDown;
            scheduleType = ScheduleType.SpecifyTime;
            MessageTrayShow = true;
            MessageNoticeShow = false;

            string s = $@"
                        {nameof(setdate)}:{setdate}
                        {nameof(date)}:{date}
                        {nameof(hour)}:{hour}
                        {nameof(minute)}:{minute}
                        {nameof(second)}:{second}
                        {nameof(operation)}:{operation}
                        {nameof(scheduleType)}:{scheduleType}
                        {nameof(doingSchedule)}:{doingSchedule}
                        {nameof(CloseToTray)}:{CloseToTray}
                        {nameof(MessageTrayShow)}:{MessageTrayShow}
                        {nameof(MessageNoticeShow)}:{MessageNoticeShow}
                        ";
            File.WriteAllText(_filePath, s);
        }

        public static void WriteStore()
        {
            //MessageBox.Show(schedule);
            //File.WriteAllText(_filePath, schedule);

            string s = $@"
                        {nameof(setdate)}:{setdate}
                        {nameof(date)}:{date}
                        {nameof(hour)}:{hour}
                        {nameof(minute)}:{minute}
                        {nameof(second)}:{second}
                        {nameof(operation)}:{operation}
                        {nameof(scheduleType)}:{scheduleType}
                        {nameof(doingSchedule)}:{doingSchedule}
                        {nameof(CloseToTray)}:{CloseToTray}
                        {nameof(MessageTrayShow)}:{MessageTrayShow}
                        {nameof(MessageNoticeShow)}:{MessageNoticeShow}
                        ";
            File.WriteAllText(_filePath, s);
        }

        public static void ReadStore()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filePath)
                    .Select(x => x.Trim())
                    .Where(x => x.Length > 0)
                    .ToArray();


                foreach (var line in lines)
                {
                    if (line.StartsWith($"{nameof(date)}:"))
                    {
                        date = line.Split(':')[1];
                    }
                    else if (line.StartsWith($"{nameof(setdate)}:"))
                    {
                        setdate = line.Split(':')[1];
                    }
                    else if (line.StartsWith($"{nameof(hour)}:"))
                    {
                        hour = int.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(minute)}:"))
                    {
                        minute = int.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(second)}:"))
                    {
                        second = int.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(operation)}:"))
                    {
                        operation = (ShutDownOperation)Enum.Parse(typeof(ShutDownOperation), line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(scheduleType)}:"))
                    {
                        scheduleType = (ScheduleType)Enum.Parse(typeof(ScheduleType), line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(doingSchedule)}:"))
                    {
                        doingSchedule = bool.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(CloseToTray)}:"))
                    {
                        CloseToTray = bool.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(MessageTrayShow)}:"))
                    {
                        MessageTrayShow = bool.Parse(line.Split(':')[1]);
                    }
                    else if (line.StartsWith($"{nameof(MessageNoticeShow)}:"))
                    {
                        MessageNoticeShow = bool.Parse(line.Split(':')[1]);
                    }
                }
            }
            catch
            {
                //Instance = DefaultSettings();
            }
        }

    }
}
