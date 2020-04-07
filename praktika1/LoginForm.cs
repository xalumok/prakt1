using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPass.Text;
            pass = HashFunc.CalculateMD5Hash(pass);
            if (userExists(login, pass))
            {
                MessageBox.Show("You logged in!");
            }
            else
            {
                MessageBox.Show("User does not exist!");
            }
        }

        private bool userExists(string login, string pass)
        {
            string query = $"SELECT login FROM users where login='{login}' and pass='{pass}'";
            DataTable DT = DBFunc.sendRequest(query);
            return (DT.Rows.Count != 0);
        }

        private void linkLabelReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadingForm loading = new LoadingForm();
            loading.Show();
            
            loading.FormClosing += new FormClosingEventHandler(formClosing);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.CenterToScreen();
        }
    }
}
