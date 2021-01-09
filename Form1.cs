using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterControl
{
    public partial class Form1 : Form
    {
        int[] days = new int[7];
        public Form1()
        {
            InitializeComponent();
        }

        private int todayIs()
        {
            DateTime thisDay = DateTime.Today;
            return (int) thisDay.DayOfWeek;
        }

        private void addWater(int res)
        {
            int today = todayIs();
            if (today == 0)
            {
                today = 6;
            }
            else
            {
                today -= 1;
            }
            int result = res;
            try
            {
                days[today] += result;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\watercontrol";
                using (StreamWriter f = new StreamWriter(path + @"\data.txt"))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        f.WriteLine(days[i]);
                    }
                }
                using (StreamReader f = new StreamReader(path + @"\data.txt"))
                {
                    string[] textArr = new string[7];
                    for (int i = 0; i < 7; i++)
                    {
                        textArr[i] = f.ReadLine();
                        days[i] = Convert.ToInt32(textArr[i]);
                    }
                    label8.Text = textArr[0];
                    label9.Text = textArr[1];
                    label10.Text = textArr[2];
                    label11.Text = textArr[3];
                    label12.Text = textArr[4];
                    label13.Text = textArr[5];
                    label14.Text = textArr[6];
                    label15.Text = "Успешно прочитана информация";
                }
                label15.Text = "Успешно добавлено";
            }
            catch (Exception ex)
            {
                label15.Text = $"Возникло исключение: {ex}";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\watercontrol";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                using (StreamWriter f = new StreamWriter(path + @"\data.txt"))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        f.WriteLine("0");
                    }
                }
                label15.Text = "Создана папка для хранения данных";
            }
            using (StreamReader f = new StreamReader(path + @"\data.txt"))
            {
                string[] textArr = new string[7];
                for (int i = 0; i < 7; i++)
                {
                    textArr[i] = f.ReadLine();
                    days[i] = Convert.ToInt32(textArr[i]);
                }
                label8.Text = textArr[0];
                label9.Text = textArr[1];
                label10.Text = textArr[2];
                label11.Text = textArr[3];
                label12.Text = textArr[4];
                label13.Text = textArr[5];
                label14.Text = textArr[6];
                label15.Text = "Успешно прочитана информация";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите объём жидкости(в МЛ):");
            try
            {
                int res = Convert.ToInt32(result);
                addWater(res);
            }
            catch (Exception ex)
            {
                label15.Text = $"Возникло исключение: {ex}";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\watercontrol";
                using(StreamWriter f = new StreamWriter(path + @"\data.txt"))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        f.WriteLine("0");
                    }
                }
                using (StreamReader f = new StreamReader(path + @"\data.txt"))
                {
                    string[] textArr = new string[7];
                    for (int i = 0; i < 7; i++)
                    {
                        textArr[i] = f.ReadLine();
                        days[i] = Convert.ToInt32(textArr[i]);
                    }
                    label8.Text = textArr[0];
                    label9.Text = textArr[1];
                    label10.Text = textArr[2];
                    label11.Text = textArr[3];
                    label12.Text = textArr[4];
                    label13.Text = textArr[5];
                    label14.Text = textArr[6];
                }
                label15.Text = "Обнулено";
            }
            catch(Exception ex)
            {
                label15.Text = $"Возникло исключение: {ex}";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addWater(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addWater(200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addWater(250);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addWater(500);
        }
    }
}
