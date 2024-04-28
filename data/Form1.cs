using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DateTime date1 = DateTime.Parse(dateTimePicker1.Text);
            DateTime date2 = DateTime.Parse(dateTimePicker2.Text);
            int days = 1+(date2-date1).Days;
            label1.Text = days.ToString();
            if (radioRus.Checked)
            {
                int summ = days * 700;
                label8.Text = summ.ToString();
            }
            if (radioBugor.Checked)
            {
                
                if (radioAir.Checked)
                {
                    if (days == 1)
                    {
                        int summ = days * 1000;
                        label8.Text = summ.ToString();
                    }
                    else
                    {
                        int summ = ((days - 1) * 1000) + 700;
                        label8.Text = summ.ToString();
                    }
                }
                if(radioBus.Checked || radioRails.Checked)
                {
                    string time1 = maskedTextBox1.Text;
                    string time2 = maskedTextBox2.Text;
                    DateTime t1 = DateTime.ParseExact(time1, "HH:mm", CultureInfo.InvariantCulture);
                    DateTime t2 = DateTime.ParseExact(time2, "HH:mm", CultureInfo.InvariantCulture);
                    DateTime date3 = DateTime.Parse(dateTimePicker3.Text);
                    DateTime date4 = DateTime.Parse(dateTimePicker4.Text);
                    int days1 = date3.Day;
                    int days2 = date4.Day;
                    if (days1!=days2)
                    {
                        if (days == 1)
                        {
                            int summ = days * 1000;
                            label8.Text = summ.ToString();
                        }
                        else
                        {
                            int summ = ((days - 2) * 1000) + (700 * 2);
                            label8.Text = summ.ToString();
                        }
                    }
                     else if(t1 < t2 || days1 <= days2)
                    {
                        MessageBox.Show("Проверьте 1-й Зарубежный город");
                    }
                    else
                    {
                        int summ = ((days - 1) * 1000) + 700;
                        label8.Text = summ.ToString();
                    }
                }

            }
        }

        private void radioBugor_CheckedChanged(object sender, EventArgs e)
        {
            transport.Visible = true;
        }

        private void radioRus_CheckedChanged(object sender, EventArgs e)
        {
            transport.Visible = false;
            panZone.Visible = false;
        }

        private void radioAir_CheckedChanged(object sender, EventArgs e)
        {
            panZone.Visible = false;
        }

        private void radioRails_CheckedChanged(object sender, EventArgs e)
        {
            panZone.Visible = true;
        }

        private void radioBus_CheckedChanged(object sender, EventArgs e)
        {
            panZone.Visible = true;
        }
    }
}
