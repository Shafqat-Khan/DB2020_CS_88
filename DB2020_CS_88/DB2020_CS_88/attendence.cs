using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2020__CS__131
{
    public partial class attendence : Form
    {
        public attendence()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f5 = new Form3();
            this.Hide();
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_Attendence sa = new Student_Attendence();
            this.Hide();
            sa.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lookup l = new Lookup();
            this.Hide();
            l.Show();
        }
    }
}
