using System.Windows.Forms;

namespace Homework1
{
    public partial class Form1 : Form
    {
        private int b = 0;
        object locker = new();
        public Form1()
        {
            InitializeComponent();
            label1.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Fibonachi()
        {
            int j = 1;
            for (int i = 1; i <= 100; i += j)
            {

                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => textBox1.Text += " " + i.ToString()));
                    Thread.Sleep(b);
                }
                   
                j = i - j;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Thread thread = new Thread(Fibonachi);
            thread.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("Текущее значение: {0} секунд", trackBar1.Value);
            b = Convert.ToInt32(trackBar1.Value) * 1000;
        }
    }
}