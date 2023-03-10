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
    public partial class Assessment : Form
    {
        public Assessment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();


            SqlCommand cmd = new SqlCommand("INSERT  INTO  Assessment values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", textBox4.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Assessment Details Added Successfully!!!!!11");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE StudentResult From Assessment ,AssessmentComponent  WHERE Assessment.Id=AssessmentComponent.AssessmentId and AssessmentComponent.Id=StudentResult.AssessmentComponentId and Assessment.Title=@tit and Assessment.DateCreated=@dt", con);
            cmd.Parameters.AddWithValue("@tit", textBox1.Text);
            cmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(textBox2.Text));
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("DELETE AssessmentComponent From Assessment  WHERE Assessment.Id=AssessmentComponent.AssessmentId and Assessment.Title=@tit1 and Assessment.DateCreated=@dt1 ", con);
            cmd1.Parameters.AddWithValue("@tit1", textBox1.Text);
            cmd1.Parameters.AddWithValue("@dt1", Convert.ToDateTime(textBox2.Text));
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("DELETE Assessment WHERE Title=@tit2 and DateCreated=@dt2 ", con);
            cmd2.Parameters.AddWithValue("@tit2", textBox1.Text);
            cmd2.Parameters.AddWithValue("@dt2", Convert.ToDateTime(textBox2.Text));
            cmd2.ExecuteNonQuery();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Title ,DateCreated,TotalMarks,TotalWeightage from Assessment where Title=@title", con);
            cmd.Parameters.AddWithValue("@title", textBox1.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                textBox2.Text = da.GetValue(1).ToString();
                textBox3.Text = da.GetValue(2).ToString();
                textBox4.Text = da.GetValue(3).ToString();

            }
            if (textBox1.Text == "")
            {
                textBox2.ResetText();
                textBox3.Clear();
                textBox4.Clear();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Assessment SET DateCreated=@datec, TotalMarks=@tm,TotalWeightage=@tw WHERE Title=@t", con);
            cmd.Parameters.AddWithValue("@t", textBox1.Text);
            cmd.Parameters.AddWithValue("@datec", Convert.ToDateTime(textBox2.Text));
            cmd.Parameters.AddWithValue("@tm", textBox3.Text);
            cmd.Parameters.AddWithValue("@tw", textBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Assessment Updated Successfully Click View To show Updates");
        }
    }
}
