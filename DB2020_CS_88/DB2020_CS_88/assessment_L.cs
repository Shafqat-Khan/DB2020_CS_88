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
    public partial class assessment_L : Form
    {
        public assessment_L()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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
            MessageBox.Show(" Rubric IDs Loaded Successfully!!!!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id from Assessment ", con);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                comboBox2.Items.Add(dr["Id"].ToString());



            }
            MessageBox.Show(" Assessments IDs Loaded Succesfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String assessment_id = comboBox2.Text;
            int marks = 0;
            int totalmrks = 0;
            SqlCommand cmd1 = new SqlCommand("Select Sum(ac.TotalMarks) From Assessment a Join AssessmentComponent ac On a.Id = ac.AssessmentId Where a.Id ='" + assessment_id + "'", con);

            SqlDataReader r1, r2;
            r1 = cmd1.ExecuteReader();
           
            
                while (r1.Read())
                {
                try
                {
                    marks = (int)r1.GetValue(0);
                }
                catch(Exception)
                {
                    marks = 0;
                }
                   
                }

            
          
            marks = marks + Convert.ToInt32(textBox2.Text);




            r1.Close();
            SqlCommand cmd3 = new SqlCommand("Select TotalMarks From Assessment Where Id ='" +assessment_id + "'", con);
            r2 = cmd3.ExecuteReader();
            while (r2.Read())
            {
                totalmrks = (int)r2.GetValue(0);
            }
            r2.Close();
        
            if (marks <= totalmrks)
            {
                SqlCommand cmd = new SqlCommand("INSERT  INTO  AssessmentComponent values( @Name, @RubricId, @TotalMarks, @DateCreated,@DateUpdated,@AssessmentId)", con);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@RubricId", Convert.ToInt32(comboBox1.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", Convert.ToInt32(textBox2.Text));
                cmd.Parameters.AddWithValue("@DateCreated", Convert.ToDateTime(textbox3.Value));
                cmd.Parameters.AddWithValue("@DateUpdated", Convert.ToDateTime(textbox4.Value));
                cmd.Parameters.AddWithValue("@AssessmentId", Convert.ToInt32(comboBox2.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Assessment Level Successfully Added!!!!!!!!!!");

            }
            else
            {
                MessageBox.Show("Your addedd component marks excedded your assessment marks by  " + (marks-totalmrks) + "");
            }

               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete from AssessmentComponent WHERE RubricId=@rid and AssessmentId=@mlevel and Name=@name", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@rid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@mlevel", comboBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Assessment Component Record Deleted Successfully!!!!!!!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void assessment_L_Load(object sender, EventArgs e)
        {
           




        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET RubricId=@r,TotalMarks=@tm, DateCreated=@dc,DateUpdated=@du,AssessmentId=@aid  where Name=@name", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@r", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tm", textBox2.Text);
            cmd.Parameters.AddWithValue("@dc", Convert.ToDateTime(textbox3.Text));
            cmd.Parameters.AddWithValue("@du", DateTime.Now);
            cmd.Parameters.AddWithValue("@aid", comboBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Assessment Levels  Updated Successfully Click View To show Updates");
        }

    }
    }

