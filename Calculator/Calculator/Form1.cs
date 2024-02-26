using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool flag;
        double first_num;

        // нажатие кнопки сброса
        private void button_clear(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // нажатие кнопки равно
        private void button_equally(object sender, EventArgs e)
        {
            double second_num = Convert.ToDouble(textBox1.Text);

            switch (textBox2.Text.ToString()) 
            {
                case "+":
                    textBox1.Text = Convert.ToString(first_num + second_num); break;
                case "-":
                    textBox1.Text = Convert.ToString(first_num - second_num); break;
                case "*":
                    textBox1.Text = Convert.ToString(first_num * second_num); break;
                case "/":
                    textBox1.Text = Convert.ToString(first_num / second_num); break;
            }

            textBox2.Text = "";
            flag = true; // для того чтоб начать набор цифр сначала
        }

        // нажатие кнопок знака операции
        private void button_mark(object sender, EventArgs e)
        {
            Button B = (Button)sender; // получаем значение кнопки

            flag = true; // для того чтоб начать набор цифр сначала
            textBox2.Text = B.Text;
            first_num = Convert.ToDouble(textBox1.Text);
        }

        // нажатие кнопок с цифрами
        private void button_numbers(object sender, EventArgs e)
        {
            Button B = (Button)sender; // получаем значение кнопки

            if (flag) // проверка внесенного знака
            {
                flag = false;
                textBox1.Text = "0";
            }

            if (textBox1.Text == "0")
                textBox1.Text = B.Text;
            else
                textBox1.Text += B.Text;
        }

        // нажатие кнопки разделителя
        private void button_comma(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
                textBox1.Text += ",";
        }
    }
}
