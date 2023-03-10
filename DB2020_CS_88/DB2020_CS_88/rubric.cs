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
    public partial class rubric : Form
    {
        public rubric()
        {
            InitializeComponent();
        }

        private void rubric_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id from Clo ", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                comboBox1.Items.Add(dr["Id"].ToString());


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Details,CloId from Rubric where Id=@id ", con);

            cmd.Parameters.AddWithValue("@Id",textBox1.Text);
            cmd.CommandType = CommandType.Text;
            SqlDataReader da = cmd.ExecuteReader();


            
            while (da.Read())
                {
               


                    textBox2.Text = da.GetValue(0).ToString();
                    comboBox1.Text = da.GetValue(1).ToString();

                }
                if (textBox1.Text == "")
                {
                    textBox2.Clear();
                    comboBox1.Text = " ";
                }

            
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text == "") && !(textBox2.Text == "") && !(comboBox1.Text == ""))
            {
                var con = Configuration.getInstance().getConnection();


                SqlCommand cmd = new SqlCommand("INSERT  INTO  Rubric values(@Id, @Details,@CloId)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@CloId", comboBox1.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Rubric Successfully Added!!!!!!!!!!");

            }
            else
            {
                MessageBox.Show("Empty Fields Can't be Added");
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE StudentResult From Rubric ,RubricLevel ,AssessmentComponent  WHERE ((Rubric.Id=RubricLevel.RubricId and RubricLevel.Id=StudentResult.RubricMeasurementId) or (Rubric.Id=AssessmentComponent.RubricId and AssessmentComponent.Id=StudentResult.AssessmentComponentId)) and Rubric.Id=@r_idddd ", con);
            cmd.Parameters.AddWithValue("@r_idddd", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("DELETE RubricLevel From Rubric  WHERE Rubric.Id=RubricLevel.RubricId and Rubric.Id=@r_iddd ", con);
            cmd1.Parameters.AddWithValue("@r_iddd", int.Parse(textBox1.Text));
            cmd1.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("DELETE AssessmentComponent From Rubric  WHERE Rubric.Id=AssessmentComponent.RubricId and Rubric.Id=@r_idd ", con);
            cmd3.Parameters.AddWithValue("@r_idd", int.Parse(textBox1.Text));
            cmd3.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("DELETE Rubric WHERE Id=@r_id ", con);
            cmd2.Parameters.AddWithValue("@r_id", int.Parse(textBox1.Text));
            cmd2.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            this.Hide();
            f.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Rubric SET Details=@det, CloId=@cid WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@det", textBox2.Text);
            cmd.Parameters.AddWithValue("@cid", comboBox1.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Rubric Updated Successfully Click View To show Updates");
        }
    }
}
