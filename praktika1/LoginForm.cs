﻿using System;
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
            if (userExists(login, pass) && userIsAdmin(login))
            {
                AdminForm mainForm = new AdminForm();
                mainForm.Show();
                mainForm.FormClosing += new FormClosingEventHandler(mainForm_closing);
                (this).Hide();
            }
            else if (userExists(login, pass))
            {
                if (userIsBanned(login))
                {
                    MessageBox.Show("This user is banned!");
                    return;
                }
                Form1 mainForm = new Form1(login);
                mainForm.Show();
                mainForm.FormClosing += new FormClosingEventHandler(mainForm_closing);
                (this).Hide();
            }
            else
            {
                MessageBox.Show("User does not exist!");
            }
        }

        private void mainForm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private bool userExists(string login, string pass)
        {
            string query = $"SELECT login FROM users where login='{login}' and pass='{pass}'";
            DataTable DT = DBFunc.sendRequest(query);
            return (DT.Rows.Count != 0);
        }

        private bool userIsBanned(string login)
        {
            string query = $"SELECT login FROM ban where login='{login}'";
            DataTable DT = DBFunc.sendRequest(query);
            return (DT.Rows.Count != 0);
        }

        private bool userIsAdmin(string login)
        {
            string query = $"SELECT login FROM admins where login='{login}'";
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
