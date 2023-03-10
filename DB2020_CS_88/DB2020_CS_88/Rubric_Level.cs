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
    public partial class Rubric_Level : Form
    {
        public Rubric_Level()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();


            SqlCommand cmd = new SqlCommand("INSERT  INTO  RubricLevel values(@RubricId, @Details,@MeasurementLevel)", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RubricId", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Details", textBox1.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", textBox2.Text);



            cmd.ExecuteNonQuery();
            MessageBox.Show("Rubric Level Successfully Added!!!!!!!!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel order by RubricId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete from RubricLevel WHERE  RubricId=@Id", con);
            cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Rubric Level Record Deleted Successfully!!!!!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void Rubric_Level_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id from Rubric ", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                comboBox1.Items.Add(dr["Id"].ToString());


            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET RubricId=@r, MeasurementLevel=@m WHERE Details=@detial", con);
            cmd.Parameters.AddWithValue("@r", comboBox1.Text);
           
            cmd.Parameters.AddWithValue("@detial", textBox1.Text);
            cmd.Parameters.AddWithValue("@m", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Rubric Levels  Updated Successfully Click View To show Updates");
        }
    }
}
