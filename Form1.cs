using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixMaster_Drop_Core
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float ServerRate = float.Parse(textBox1.Text);
            int MobRate = int.Parse(textBox2.Text);
            int MarkBonus = int.Parse(textBox3.Text);
            int MOB_LV = int.Parse(textBox4.Text);

            int BaseRate = ((int)((double)(MobRate * ServerRate)) * (MarkBonus / 100));

            int PlayerLV = int.Parse(textBox5.Text);
            if (PlayerLV > MOB_LV)
            {
                int resto = PlayerLV - MOB_LV;
                if (resto > 9)
                {
                    if (resto <= 19)
                    {
                        BaseRate = 90 * BaseRate / 100;
                    }
                    else if (resto > 29)
                    {
                        if (resto <= 39)
                        {
                            BaseRate = 70 * BaseRate / 100;
                        }
                        else if (resto > 49)
                        {
                            BaseRate = 50 * BaseRate / 100;
                        }
                        else
                        {
                            BaseRate = 60 * BaseRate / 100;
                        }
                    }
                    else
                    {
                        BaseRate = 80 * BaseRate / 100;
                    }
                }
            }

            Random rd = new Random();
            int MyDice = rd.Next(1, 10000000); 
            double Porcentage = ((double)((double)BaseRate / 10000000)) * 100;
            //MessageBox.Show(BaseRate.ToString() + " Porcentage: ");


            label5.Text = "Chance de drop: " + Porcentage.ToString("0.00000000") + "%";
            /*
            if (BaseRate <= MyDice - 1)
            {
                label5.Text = "Status: not drop";
                // not drop
            }
            else
            {
                label5.Text = "Status: DROP!!!";
                // core is droped
            }*/

        }
    }
}
