using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB2020__CS__131
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();


            SqlCommand cmd = new SqlCommand("INSERT  INTO  ClassAttendance values(@AttendanceDate)", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", Convert.ToDateTime(textBox1.Text));

            cmd.CommandType = CommandType.Text;
           
            cmd.ExecuteNonQuery();
            MessageBox.Show("Attendence Added Successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ClassAttendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            attendence a = new attendence();
            this.Hide();
            a.Show();

        }
    }
}
