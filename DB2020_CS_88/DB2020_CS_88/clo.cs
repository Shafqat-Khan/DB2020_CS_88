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
    public partial class clo : Form
    {
        public clo()
        {
            InitializeComponent();
        }

        private void clo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text == "") )
           
            {
                var con = Configuration.getInstance().getConnection();


                SqlCommand cmd = new SqlCommand("INSERT  INTO  Clo values( @Name,@DateCreated,@DateUpdated)", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@DateCreated", Convert.ToDateTime(textBox2.Text));
                cmd.Parameters.AddWithValue("@DateUpdated", Convert.ToDateTime(textBox3.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Clo Successfully Added!!!!!!!!!!");

            }
            else
            {
                MessageBox.Show("Empty Fields Can't be Added");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.DataSource = dt;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text==""))
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE StudentResult From Clo ,Rubric ,RubricLevel ,AssessmentComponent  WHERE (Clo.Id=Rubric.CloId and Rubric.Id=RubricLevel.RubricId and RubricLevel.Id=StudentResult.RubricMeasurementId and Clo.Name=@name) or (Clo.Id=Rubric.CloId and Rubric.Id=AssessmentComponent.RubricId and AssessmentComponent.Id=StudentResult.AssessmentComponentId and Clo.Name=@name) ", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("DELETE RubricLevel From Clo ,Rubric  WHERE Clo.Id=Rubric.CloId and Rubric.Id=RubricLevel.RubricId and Clo.Name=@name_c ", con);
                cmd1.Parameters.AddWithValue("@name_c", textBox1.Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("DELETE AssessmentComponent From Clo ,Rubric  WHERE Clo.Id=Rubric.CloId and Rubric.Id=AssessmentComponent.RubricId and Clo.Name=@name_cc ", con);
                cmd3.Parameters.AddWithValue("@name_cc", textBox1.Text);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("DELETE Rubric From Clo  WHERE Clo.Id=Rubric.CloId and Clo.Name=@name_ccc ", con);
                cmd2.Parameters.AddWithValue("@name_ccc", textBox1.Text);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("DELETE Clo WHERE Name=@name_cccc ", con);
                cmd4.Parameters.AddWithValue("@name_cccc", textBox1.Text);
                cmd4.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Enter Clo Name to delete");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Clo SET DateCreated= @datec, DateUpdated=@dateu WHERE Name=@name", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@datec", Convert.ToDateTime(textBox2.Text));
            cmd.Parameters.AddWithValue("@dateu", Convert.ToDateTime(DateTime.Now));

            cmd.ExecuteNonQuery();
            MessageBox.Show("CLO Updated Successfully Click View To show Updates");
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select DateCreated,DateUpdated from Clo where Name=@name", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
               
                textBox2.Text = da.GetValue(0).ToString();
                textBox3.Text = da.GetValue(1).ToString();
               
            }
            if (textBox1.Text == "")
            {
                textBox2.ResetText();
                textBox3.ResetText();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
