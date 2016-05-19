using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentSchoolSystem_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Finance fn = new Finance();
            fn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            course cs = new course();
            cs.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExamList el = new ExamList();
            el.Show();
            this.Hide();
        }
    }
}
