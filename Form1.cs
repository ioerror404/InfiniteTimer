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

namespace NFTimer
{
    public partial class Form1 : Form
    {
        DateTime startDate;
        int counter;
        int top;


        public Form1()
        {
            startDate = DateTime.Now;
            top = 0;
            counter = 0;
            InitializeComponent();
            StartTimer();
        }

        void StartTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var d = DateTime.Now.Subtract(startDate);
            Set(d);
            
            if(counter > 300)
                counter = 0;
            
            if (counter == 0)
                SetLine();
            
            counter++;
        }

        void SetLine()
        {
            string path = Directory.GetCurrentDirectory() + @"\lines.txt";
            var list = File.ReadAllLines(path);
            if(top < list.Length)
            {
                label2.Text =   list[top];
                top++;
            }
            else
            {
                top = 0;
            }
        }

        void Set(TimeSpan span)
        {
            days.Text = span.Days.ToString();
            hrs.Text = span.Hours.ToString();
            mins.Text = span.Minutes.ToString();
            secs.Text = span.Seconds.ToString();
        }

    }
}
