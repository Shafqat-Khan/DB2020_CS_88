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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rubric_Level rl = new Rubric_Level();
            this.Hide();
            rl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            this.Hide();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clo c = new clo();
            this.Hide();
                c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rubric r = new rubric();
            this.Hide();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            assessment_L al = new assessment_L();
            this.Hide();
            al.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            evaluation e_ = new evaluation();
            this.Hide();
            e_.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            attendence a = new attendence();
            this.Hide();
            a.Show();

        }
    }
}
