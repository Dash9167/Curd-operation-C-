using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CurdOperation
{
    public partial class Form1 : Form
    {

        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-AG5MD060;Initial Catalog=student_info;Integrated Security=True");
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("select * from users_info ", sqlConnection);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["name"].Width = 200;
            dataGridView1.Columns["age"].Width = 200;
            sqlConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AG5MD060;Initial Catalog=student_info;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete users_info where id=@id",conn);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
          int count=  cmd.ExecuteNonQuery();
            conn.Close();
            if(count > 0) {
                MessageBox.Show("Deleted Successfully.");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AG5MD060;Initial Catalog=student_info;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into users_info values (@id,@name,@age)", conn);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", float.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Record Added Successfully.");
            button1_Click(sender, e);
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AG5MD060;Initial Catalog=student_info;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update users_info set name=@name,age=@age where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", float.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Record Updated Successfully.");
            button1_Click(sender, e);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-AG5MD060;Initial Catalog=student_info;Integrated Security=True");
            sqlConnection.Open();
          
                SqlCommand cmd = new SqlCommand("select * from users_info where id=@id", sqlConnection);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
               
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            
          

           sqlConnection.Close();
        }
    }
}
