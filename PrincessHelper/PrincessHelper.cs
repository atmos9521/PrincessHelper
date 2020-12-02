using Newtonsoft.Json;
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
        }

        DateTime StartTime = new DateTime(2020,8,25);
        DateTime HourStartTime = new DateTime(2020,8,24,1,0,0);
        private void Search_btn_ClickAsync(object sender, EventArgs e)
        {
            DateTime SelectDate = DateTime.Parse(dateTimePicker1.Text);
            TimeSpan diffday = SelectDate - StartTime;
            //差的天數
            int diffdays = 0;
            int.TryParse(diffday.TotalDays.ToString(), out diffdays);

            int diffhours = 0;
            int.TryParse(diffday.TotalHours.ToString(), out diffhours);

            //讀檔            
            string R_Roll, SR_Roll, SSR_Roll, UR_Roll, All_Roll;
            try
            {
                R_Roll = ReturnRoll("../../json/R.json", diffdays);
                SR_Roll = ReturnRoll("../../json/SR.json", diffdays);
                SSR_Roll = ReturnRoll("../../json/SSR.json", diffdays);
                UR_Roll = ReturnRoll("../../json/UR.json", diffdays);
                ShowResult_txt.Text = string.Format("R:{0}\r\nSR:{1}\r\nSSR:{2}\r\nUR:{3}"
                                            , R_Roll, SR_Roll, SSR_Roll, UR_Roll);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        string ReturnRoll(string FilePath, int diffdays) {
            string RollName = "";
            using (var sr = new StreamReader(FilePath))
            {
                string json = sr.ReadToEnd();
                //R_Rolls = JsonConvert.DeserializeObject<List<Rolls>>(Rjson);
                string [] Rolls = JsonConvert.DeserializeObject<string[]>(json);
                RollName = Rolls[diffdays % Rolls.Length];
            }
            return RollName;
        }

        Rolls Rolls = new Rolls();
        private void Input_btn_Click(object sender, EventArgs e)
        {

            //string jsonString = JsonSerializer.Serialize(NewMember_txt.Text);
        }
    }
}
