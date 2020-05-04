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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            loadUsersList();
        }

        private void loadUsersList()
        {
            var users = DBFunc.sendRequest($"SELECT login, fname as 'First Name', lname as 'Last name', email FROM users");
            dataGridViewUsers.DataSource = users;
            DataTable ban = DBFunc.sendRequest($"SELECT login FROM ban");
            HashSet<string> bannedLogins = new HashSet<string>();
            foreach(DataRow row in ban.Rows)
            {
                bannedLogins.Add(row.ItemArray[0].ToString());
            }
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                if (bannedLogins.Contains(row.Cells[0].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void loadItemsForUser(string login)
        {
            var items = DBFunc.sendRequest($"SELECT id, surname, street_name, building_num, floor_num, room_num FROM data WHERE user_login='{login}'");
            dataGridViewItems.DataSource = items;
            dataGridViewItems.Columns[0].Visible = false;
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string login = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            loadItemsForUser(login);
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            (this).Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.FormClosed += new FormClosedEventHandler(regFormClosed);
            reg.Show();
        }

        private void regFormClosed(object sender, FormClosedEventArgs e)
        {
            loadUsersList();
        }

        private void unBanUser(string login)
        {
            try
            {
                DBFunc.sendRequest($"DELETE FROM ban WHERE login='{login}'");
                loadUsersList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void banUser(string login)
        {
            try
            {
                DBFunc.sendRequest($"Insert into ban VALUES('{login}')");
                loadUsersList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonBan_Click(object sender, EventArgs e)
        {
            string login = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            banUser(login);           
        }

        private void buttonUnban_Click(object sender, EventArgs e)
        {
            string login = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            unBanUser(login);
        }
    }
}
