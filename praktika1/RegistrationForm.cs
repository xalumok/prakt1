using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika1
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }
            else
            {
                return true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPass.Text;
            string fName = textBoxFName.Text;
            string sName = textBoxSName.Text;
            string email = textBoxEMail.Text;
            if (IsValidEmail(email) == false)
            {
                MessageBox.Show("You entered invalid email!");
                return;
            }
            string errorMsg = "";
            if (ValidatePassword(pass, out errorMsg) == false)
            {
                MessageBox.Show(errorMsg);
                return;
            }
            if (checkLogin(login) == false)
            {
                MessageBox.Show("This login is already taken!");
                return;
            }
            // adding user
            string query = $"INSERT INTO users values(0, '{login}', '{HashFunc.CalculateMD5Hash(pass)}', '{fName}', '{sName}', '{email}')";
            DBFunc.sendRequest(query);
            (this).Close();
        }
        

        private bool checkLogin(string login)
        {
            string query = $"SELECT login FROM users where login='{login}'";
            DataTable DT = DBFunc.sendRequest(query);
            return (DT.Rows.Count == 0);
        }
    }
}
