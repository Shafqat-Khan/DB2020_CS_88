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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == "") && !(textBox2.Text == "") && !(textBox3.Text == "") && !(textBox4.Text == "") && !(textBox5.Text == "") && !(comboBox1.Text == ""))
            {
                var con = Configuration.getInstance().getConnection();


                SqlCommand cmd = new SqlCommand("INSERT  INTO  Student values( @FirstName, @LastName, @Contact, @Email,@RegistrationNumber,@Status)", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status",comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added Successfully!!!!!!");

            }
            else
            {
                MessageBox.Show("Empty Fields Can't be Added");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select LookupId from  Lookup", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                comboBox1.Items.Add(dr["LookupId"].ToString());


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(textBox5.Text == ""))
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE StudentResult From Student  WHERE Student.Id=StudentResult.StudentId and Student.RegistrationNumber=@reg ", con);
                cmd.Parameters.AddWithValue("@reg", textBox5.Text);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("DELETE StudentAttendance From Student  WHERE  Student.Id=StudentAttendance.StudentId and Student.RegistrationNumber=@reg ", con);
                cmd1.Parameters.AddWithValue("@reg", textBox5.Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("DELETE Student WHERE RegistrationNumber=@reg1 ", con);
                cmd2.Parameters.AddWithValue("@reg1", textBox5.Text);
                cmd2.ExecuteNonQuery();

            }
            else
            {
                MessageBox.Show("Enter registration to delete student");
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(textBox5.Text == ""))
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName= @F_Name, LastName=@L_Name, Contact=@Contact, Email=@Email,Status=@Status WHERE RegistrationNumber=@Reg", con);

                cmd.Parameters.AddWithValue("@F_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@L_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);

                cmd.Parameters.AddWithValue("@Email", textBox4.Text);

                cmd.Parameters.AddWithValue("@Reg", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully Click Show data to View");

            }
            else
            {
                MessageBox.Show("Enter Registration Number of Student To Load Data and then Update");
            }
               
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select FirstName ,LastName,Contact,Email,Status from Student where RegistrationNumber=@reg", con);
            cmd.Parameters.AddWithValue("@reg", textBox5 .Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                textBox1.Text = da.GetValue(0).ToString();
                textBox2.Text = da.GetValue(1).ToString();
                textBox3.Text = da.GetValue(2).ToString();
                textBox4.Text = da.GetValue(3).ToString();
                comboBox1.Text = da.GetValue(4).ToString();
               
            }
            if (textBox5.Text == "")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
                

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();

        }
    }
}
