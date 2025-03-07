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
    public partial class Login : Form
    {
        public Login()
        {
            
          
            InitializeComponent();
            guna2Button2.Hide();


        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Connection String   
            SqlConnection con = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Userlogins where UserName=@UserName and Password =@Password", con);
            cmd.Parameters.AddWithValue("@UserName", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Connection open here   
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (String.IsNullOrEmpty(guna2TextBox1.Text) && String.IsNullOrEmpty(guna2TextBox2.Text))
            {
                // return required field message 
                guna2TextBox1.BorderColor = Color.Red;
                guna2TextBox2.BorderColor = Color.Red;                

            }
            else if (String.IsNullOrEmpty(guna2TextBox1.Text))
            {
                // return required field message 
                guna2TextBox1.BorderColor = Color.Red;

            }
           else if (String.IsNullOrEmpty(guna2TextBox2.Text))
            {
                // return required field message 
                guna2TextBox2.BorderColor = Color.Red;

            }
            
            else if (dt.Rows.Count > 0)
            {

                //after successful it will redirect  to next page .
                this.Hide();
                var WelcomePage = new WelcomePage();
                WelcomePage.Closed += (s, args) => this.Close();
                WelcomePage.Show();
            }
 
            else
            {
                error err = new error();
                err.ShowDialog();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var SignUp = new Signup();
            SignUp.ShowDialog();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Signup cl = new Signup();
            cl.Close();
            Application.ExitThread();
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        Point lastPoint;
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if(guna2TextBox2.PasswordChar == '*')
            {
                guna2Button5.BringToFront();
                guna2TextBox2.PasswordChar = '\0';
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.PasswordChar == '\0')
            {
                guna2Button7.BringToFront();
                guna2TextBox2.PasswordChar = '*';
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Forget = new Forget();
            Forget.ShowDialog();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
    }
