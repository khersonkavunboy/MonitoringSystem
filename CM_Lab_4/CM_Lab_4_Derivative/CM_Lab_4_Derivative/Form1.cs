using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CM_Lab_4_Derivative
{
    public partial class Form1 : Form
    {
        // но что-то вроде «задана функция -> найти 1 и 2 производную ->
        // построить 2 графика(с центральной разницей и аналитический)»
        
        public Form1()
        {
            InitializeComponent();
            a = -2;
            b = 1;
            step = 0.01;
        }

        private void Form1_Load(object sender, EventArgs handler)
        {

        }
        private double Function_x3sinx_1(double x) {

            return Math.Sin(x*x+1);
        }
        ///--------------
        private double FirstDerivative(double f,double h) {
            
            return (Function_x3sinx_1(f+h) - Function_x3sinx_1(f-h)) / (2 * h);
        }

        private double SecondDerivative(double f, double h)
        {
            return (Function_x3sinx_1(f - h) - 2 * Function_x3sinx_1(f) + Function_x3sinx_1(f + h)) / (h * h);
        }


        double a;
        double b;
        double step;


        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < derivative1_chart.Series.Count; i++)
            {
                derivative1_chart.Series[i].Points.Clear();
            }
            
            double x = a;
            
            double RightDifference = (Function_x3sinx_1(x + step) - Function_x3sinx_1(x)) / step;
            derivative1_chart.Series[0].Points.AddXY(x, Function_x3sinx_1(x));
            derivative1_chart.Series[1].Points.AddXY(x, RightDifference);
            x += step;

            while (x < b)
            {
                derivative1_chart.Series[0].Points.AddXY(x, 2*x*Math.Cos(Math.Pow(x,2)+1));
                derivative1_chart.Series[1].Points.AddXY(x, FirstDerivative(x, step));
                x += step;
            }

           double LeftDifference = (Function_x3sinx_1(x) - Function_x3sinx_1(x - step)) / step;
           derivative1_chart.Series[0].Points.AddXY(x, 2 * x * Math.Cos(Math.Pow(x, 2) + 1));
           derivative1_chart.Series[1].Points.AddXY(x, LeftDifference);

        }



        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < derivative1_chart.Series.Count; i++)
            {
                derivative1_chart.Series[i].Points.Clear();
            }

            double x = a;
            while (x <= b)
            {
                derivative1_chart.Series[0].Points.AddXY(x,2*Math.Cos(Math.Pow(x,2)+1) - 4*Math.Pow(x,2) *Math.Sin(Math.Pow(x,2)+1));
                derivative1_chart.Series[1].Points.AddXY(x, SecondDerivative(x, step));
                x += step;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
