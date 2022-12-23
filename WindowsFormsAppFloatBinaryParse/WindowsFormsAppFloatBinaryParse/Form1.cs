using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFloatBinaryParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool binaryValue;
        Int64 temp;

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            temp = Convert.ToInt64(x);
            double baseTemp =0.5;
            double decMantissa = 0;
            double lastDigit = 0;

            #region decimalToBinary
            textBox2.Text = "";
            while (temp > 0)
            {
                binaryValue = Convert.ToBoolean(temp % 2);
                if (binaryValue)
                {
                    textBox2.Text = "1" + textBox2.Text;
                }
                else
                {
                    textBox2.Text = "0" + textBox2.Text;
                }

                temp = temp / 2;
                if (temp == 1)
                {
                    textBox2.Text = "1" + textBox2.Text;
                    break;
                }
                else if (temp == 0)
                {
                    textBox2.Text = "0" + textBox2.Text;
                    break;
                }
            }
            #endregion

            #region binaryToDecimal
            textBox4.Text = "";
            temp = 0;
            while (textBox3.TextLength<4)
            {
                textBox3.Text = "0" + textBox3.Text;
            }
            for (int i = textBox3.TextLength; i > textBox3.TextLength-4; i--)
            {
                temp = (long)(temp + Convert.ToInt64(textBox3.Text.Substring(i-1,1))*Math.Pow(2,4-i));
                lastDigit = Convert.ToInt64(textBox3.Text.Substring(i - 1, 1));
                decMantissa = decMantissa + lastDigit * baseTemp;
                baseTemp = baseTemp / 2;
            }
            textBox4.Text = temp.ToString();

            textBox5.Text=decMantissa.ToString();

            #endregion
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !("\b01".Contains(e.KeyChar));//textBox3 become binary form
        }

    }
}
