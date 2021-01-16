using Newtonsoft.Json;
using PrincessHelper.DataFormet;
using PrincessHelper.json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PrincessHelper
{
    public partial class PrincessHelper : Form
    {
        public PrincessHelper()
        {
            InitializeComponent();
            //讀取腳色日期檔
            ReadReNewDate();
            //取得腳色數量
            GetRollsCount();
        }

        int URRollsCount = 0, AllRollsCount = 0;
        private void GetRollsCount()
        {
            try
            {
                using (var sr = new StreamReader("../../json/All.json"))
                {
                    string json = sr.ReadToEnd();
                    string[] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                    AllRollsCount = Rolls.Length;
                    sr.Close();
                }
                using (var sr = new StreamReader("../../json/UR.json"))
                {
                    string json = sr.ReadToEnd();
                    string[] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                    URRollsCount = Rolls.Length;
                    sr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        DateTime StartTime = new DateTime(2020, 8, 25);
        //DateTime HourStartTime = new DateTime(2020, 12, 23, 14, 0, 0);
        //DateTime URStartTime = new DateTime(2020, 12, 12);
        DateTime HourStartTime { get; set; }
        DateTime URStartTime { get; set; }
        private void Search_btn_ClickAsync(object sender, EventArgs e)
        {
            //還沒取得日期至GetStarDay取得
            if (!getdate)
            {
                GetSpecialDay();
            }

            DateTime SelectDate = DateTime.Parse(dateTimePicker1.Text);
            TimeSpan diffday = SelectDate - StartTime;
            //差的天數
            int diffdays = 0;
            int.TryParse(diffday.TotalDays.ToString(), out diffdays);

            //讀檔            
            string R_Roll, SR_Roll, SSR_Roll, UR_Roll;
            try
            {
                R_Roll = ReturnRoll("../../json/R.json", diffdays);
                SR_Roll = ReturnRoll("../../json/SR.json", diffdays);
                SSR_Roll = ReturnRoll("../../json/SSR.json", diffdays);

                diffday = SelectDate - URStartTime;
                int.TryParse(diffday.TotalDays.ToString(), out diffdays);
                UR_Roll = ReturnRoll("../../json/UR.json", diffdays);
                ShowResult_txt.Text = string.Format("R:{0}\r\nSR:{1}\r\nSSR:{2}\r\nUR:{3}\r\n\r\n限時精靈:"
                                            , R_Roll, SR_Roll, SSR_Roll, UR_Roll);

                diffday = SelectDate - HourStartTime;
                int diffhours = 0;
                int.TryParse(diffday.TotalHours.ToString(), out diffhours);
                ReturnAllRoll(diffhours);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        string ReturnRoll(string FilePath, int diffdays)
        {
            string RollName = "";
            using (var sr = new StreamReader(FilePath))
            {
                string json = sr.ReadToEnd();
                string[] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                if (FilePath.Contains("UR")) {
                    RollName = Rolls[diffdays % (Rolls.Length - FileDiffDays)];
                }
                else
                {
                    RollName = Rolls[diffdays % Rolls.Length];
                }
                sr.Close();
            }
            return RollName;
        }
        void ReturnAllRoll(int diffhours)
        {
            string[] RollName = new string[12];
            using (var sr = new StreamReader("../../json/All.json"))
            {
                string json = sr.ReadToEnd();
                string[] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                DateTime SelectDate = DateTime.Parse(dateTimePicker1.Text);

                for (int i = 1; i <= 24; i++)
                {
                    if (i == DateTime.Now.Hour)
                    {
                        Hour_Role_txt.Text = string.Format("{0}:00\t{1}", i, Rolls[(diffhours + i) % (Rolls.Length - FileDiffDays)]);
                    }
                    ShowResult_txt.Text = string.Format("{0}\r\n{1}:00\t{2}", ShowResult_txt.Text, i, Rolls[(diffhours + i) % (Rolls.Length - FileDiffDays)]);
                }
                sr.Close();
            }
        }

        List<RollDate> RollDates = new List<RollDate>();
        void ReadReNewDate()
        {
            try
            {
                using (var sr = new StreamReader("../../json/NewRollDate.json"))
                {
                    RollDates.Clear();
                    string json = sr.ReadToEnd();
                    List<RollDate> Rolldatas = JsonConvert.DeserializeObject<List<RollDate>>(json);
                    foreach (var Rolldates in Rolldatas)
                    {
                        RollDates.Add(Rolldates);
                    }
                    URStartTime = DateTime.Parse(Rolldatas[Rolldatas.Count - 1].Date[0]);
                    string GetHourdata = Rolldatas[Rolldatas.Count - 1].Date[1];
                    DateTime getdaytime = new DateTime(
                        int.Parse(GetHourdata.Substring(0, 4)),
                        int.Parse(GetHourdata.Substring(4, 2)),
                        int.Parse(GetHourdata.Substring(6, 2)),
                        int.Parse(GetHourdata.Substring(8, 2)),
                        0, 0
                        );
                    HourStartTime = getdaytime;
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        bool getdate = false;
        //取得須計算的日期起始點
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getdate = false;
            GetSpecialDay();
        }
        int FileDiffDays = 0;
        void GetSpecialDay()
        {
            DateTime SelectDate = DateTime.Parse(dateTimePicker1.Text);
            
            for (int i = RollDates.Count - 1; i >= 0; i--)
            {
                DateTime DataDate = DateTime.Parse(RollDates[i].Date[0]);
                if (DataDate <= SelectDate)
                {
                    URStartTime = DataDate;
                    DateTime getdaytime = new DateTime(
                        int.Parse(RollDates[i].Date[1].Substring(0, 4)),
                        int.Parse(RollDates[i].Date[1].Substring(4, 2)),
                        int.Parse(RollDates[i].Date[1].Substring(6, 2)),
                        int.Parse(RollDates[i].Date[1].Substring(8, 2)),
                        0, 0
                        );
                    HourStartTime = getdaytime;
                    getdate = true;
                    return;
                }
                else
                {
                    FileDiffDays++;
                }
            }
        }

        Rolls Rolls = new Rolls();
        private void Input_btn_Click(object sender, EventArgs e)
        {
            bool Continue = true;
            string NewRollname = NewMember_txt.Text;
            if (NewRollname == "")
            {
                return;
            }
            //1.讀取ALL & UR.json
            try
            {
                Continue = WriteNEWRoll("../../json/All.json", NewRollname);
                if (Continue)
                {
                    Continue = WriteNEWRoll("../../json/UR.json", NewRollname);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //新增腳色失敗 不執行後面更新日期
            if (!Continue)
            {
                return;
            }

            //3.計算新起算日
            DateTime NewHourTime = HourStartTime.AddHours(AllRollsCount-1);
            DateTime NewURStartTime = URStartTime.AddDays(URRollsCount-1);

            //日期不同才更新日期檔
            if (DateTime.Parse(RollDates[RollDates.Count - 1].Date[0]) != NewURStartTime)
            {
                string Datejson = "";
                //4.讀取日期檔json
                using (var sr = new StreamReader("../../json/NewRollDate.json"))
                {
                    Datejson = sr.ReadToEnd();

                    RollDate NewDate = new RollDate();
                    //插入新日期
                    Datejson = Datejson.Substring(0, Datejson.Length - 3);
                    Datejson = string.Format("{0},\r\n\t{{" +
                                             "\"Date\":[\"{1}/{2}/{3}\"," +
                                             "\"{4}{5}{6}{7}\"]}}\r\n]"
                                             , Datejson
                                             , NewURStartTime.Year, DateAddZero(NewURStartTime.Month), DateAddZero(NewURStartTime.Day)
                                             , NewHourTime.Year, DateAddZero(NewHourTime.Month), DateAddZero(NewHourTime.Day), DateAddZero(NewHourTime.Hour)
                                             );
                    sr.Close();
                    //5.加入新日期
                    System.IO.File.WriteAllText("../../json/NewRollDate.json", Datejson);

                    //6.更新程式起始日期資料
                    HourStartTime = NewHourTime;
                    URStartTime = NewURStartTime;
                }
            }
        }

        string DateAddZero(int Num)
        {
            string ResultNum = Num.ToString();
            if (Num.ToString().Length == 1)
            {
                ResultNum = string.Format("0{0}", Num);
            }
            return ResultNum;
        }

        private bool WriteNEWRoll(string ReWriteFileName, string NewRollname)
        {
            using (var sr = new StreamReader(ReWriteFileName))
            {
                string json = sr.ReadToEnd();
                string[] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                if (ReWriteFileName.Contains("UR"))
                {
                    URRollsCount = Rolls.Length + 1;
                }
                else if (ReWriteFileName.Contains("All"))
                {
                    AllRollsCount = Rolls.Length + 1;
                }
                string Writedatas = "";//準備寫入UR腳色資料
                foreach (string Roll in Rolls)
                {
                    if (Roll == NewRollname)
                    {
                        MessageBox.Show("此腳色已新增");
                        return false;
                    }
                    //第一個腳色
                    else if (Writedatas == "")
                    {
                        Writedatas = string.Format("[\r\n\"{0}\",\r\n", Roll);
                    }
                    else
                    {
                        Writedatas = string.Format("{0}\"{1}\",\r\n", Writedatas, Roll);
                    }
                }
                sr.Close();

                //2.加入新腳色
                Writedatas = string.Format("{0}\"{1}\"\r\n]", Writedatas, NewRollname);
                System.IO.File.WriteAllText(ReWriteFileName, Writedatas);
            }
            return true;
        }

        private void PrincessHelper_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //讓Form再度顯示，並寫狀態設為Normal
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
