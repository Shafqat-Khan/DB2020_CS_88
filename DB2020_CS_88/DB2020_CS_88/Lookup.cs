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
    public partial class Lookup : Form
    {
        public Lookup()
        {
            InitializeComponent();
        }

        private void Lookup_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            attendence a = new attendence();
            this.Hide();
            a.Show();
        }
    }
}
