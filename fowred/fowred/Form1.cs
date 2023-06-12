using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fowred
{
    public partial class Form1 : Form
    {
        int n;
        double fx;
        double[] x = new double[250];
        double[,] y = new double[250, 250];


        //دالة من أجل حساب قيمة السلسلة في القانون
        double u_cal(double r, int n)
        {
            double temp = r;
            for (int i = 1; i < n; i++)
                temp = temp * (r - i);
            return temp;
        }
        //دالة من أجل حساب العاملة
        int fact(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;
            return f;
        }
        private void UseNumberOnly(KeyPressEventArgs e)//دالة من أجل ادخال الارام فقط
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case (char)Keys.Back:
                case ',':
                case '.':
                case '-':
                




                    e.Handled = false;
                    break;
                default:
                    MessageBox.Show("الرجاء إخال ارقام وفواصل فقط");
                    e.Handled = true;
                    break;

            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UseNumberOnly(e);
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            UseNumberOnly(e);
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            UseNumberOnly(e);
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            UseNumberOnly(e);
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            //n: تمثل عدد العناصر المدخلة بأحد التكست بوكس من أجل تعريفها بالعدادات 
            n = txt1.Text.Split(',').Length;

            //شرط من أجل أن تكون عدد عناصر اكس المجزأة حسب الفاصلة تساوي قيم واي
            if (txt1.Text.Split(',').Length == txt2.Text.Split(',').Length)
            {
                //حلقتان الفور تمثلان عدادات من أجل اخذ القيم من 
                //التكست بوكس وتجزيئها حسب الفاصلة ووضعها ضمن مصففوفة
                for (int i = 0; i < txt1.Text.Split(',').Length; i++)
                {
                    x[i] = Convert.ToDouble(txt1.Text.Split(',')[i]);
                }
                for (int i = 0; i < txt2.Text.Split(',').Length; i++)
                {
                    y[i, 0] = Convert.ToDouble(txt2.Text.Split(',')[i]);
                }


                ///////////////////////////////////////////////////////////////

                //حلقتان فور من أجل إسناد القيم الى المصفوفة الثنائية 
                //وذلك بمراعاة طرح قيمة الاندكس الأكبر من الأندكس الأصغر التتابع
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n - i; j++)
                        y[j, i] = y[j + 1, i - 1] - y[j, i - 1];
                }
                // عرض القيم على الريتش بوكس
                for (int i = 0; i < n; i++)
                {
                    //إظهار قيم اكس
                    richvalue.Text += "  " + x[i] + " ";
                    //إظهار قيم y0
                    for (int j = 0; j < n - i; j++)
                        richvalue.Text += "              " + y[i, j] + " ";
                    richvalue.Text += "\n\n";
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيم اكس تساوي قيم واي", "خطأ", MessageBoxButtons.OK);
            }
        }

        private void photobtn_Click(object sender, EventArgs e)
        {
            try
            {

                fx = Convert.ToDouble(txt3.Text);//تخزين قيمة الصورة بمتحول  
                int w = Convert.ToInt32(txt4.Text);//تخزين قيمة الدرجة بمتحول
                double sum = y[0, 0];//سناد قيمة العنصر الأول من المصفوفة الى المتحول المصرح عنه
                double r = (fx - x[0]) / (x[1] - x[0]);// r معطا ضمن القانون 
                for (int i = 1; i < n; i++)
                {
                    sum = sum + (u_cal(r, i) * y[0, i]) / fact(i);//قانون حساب الصورة 
                }
                txt5.Text += "f(x)=" + Math.Round(sum, w);   //من أجل حساب درجة التقريب
            }
            catch
            {
                MessageBox.Show("يرجى تعبئة الارقام بشكل صحيح");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double E = 0;
            double X = Convert.ToDouble(txt3.Text);
            int i = Convert.ToInt32(txt4.Text);
            double r = (X - x[0]) / (x[1] - x[0]);// r معطا ضمن 
            E = Math.Abs((u_cal(r, i + 1) * y[0, i + 1]) / fact(i + 1));

            txt6.Text = "E| fx |= " + E.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[,] y = new double[250, 250];
            double[] x = new double[250];
            fx = 1;
            n = 1;
            txt1.Text = ""; txt2.Text = ""; txt3.Text = ""; txt4.Text = ""; txt5.Text = ""; txt6.Text = "";
            richvalue.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
