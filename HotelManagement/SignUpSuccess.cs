using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class SignUpSuccess : Form
    {
        Form opener;
        public SignUpSuccess(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            opener.Close();
            this.Close();            
            var Login = new Login();            
            Login.Show();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup hi = new Signup();
            hi.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();


        }

        private void SignUpSuccess_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

        }
    }
}
