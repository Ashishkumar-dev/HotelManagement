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
namespace LoginPanel
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {   //Connection String   
                SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into [Userlogins] ([UserName],[Password],[MobileN],[FName],[LName],[EmailId])values(@UserName,@Password,@MobileN,@FName,@LName,@EmailId)", con);
                cmd.Parameters.AddWithValue("@UserName", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox5.Text);
                cmd.Parameters.AddWithValue("@MobileN", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@FName", guna2TextBox6.Text);
                cmd.Parameters.AddWithValue("@LName", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@EmailId", guna2TextBox4.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();               
                var SignUpSuccess = new SignUpSuccess(this);                
                SignUpSuccess.StartPosition = FormStartPosition.CenterParent;
                SignUpSuccess.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Please fill required fields");
            }

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Show();

        }
        Point lastPoint;
        private void Signup_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Signup_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
