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
    public partial class Form1 : Form
    {
        string login = "";
        DataTable items = new DataTable();
        public Form1(string _login)
        {
            InitializeComponent();
            login = _login;
            clearData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadItems();
        }

        private void loadItems()
        {
            items = DBFunc.sendRequest($"SELECT id, surname, street_name, building_num, floor_num, room_num FROM data WHERE user_login='{login}'");
            dataGridView1.DataSource = items;
            dataGridView1.Columns[0].Visible = false;
        }


        private void clearData()
        {
            dataGridView1.ClearSelection();
            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Adress adr = new Adress(textBoxSurname.Text, textBoxStreetNsme.Text, textBoxBuildingNum.Text, textBoxfloorNum.Text, textBoxRoomNumber.Text);
                DBFunc.sendRequest($"INSERT INTO data values(0, '{textBoxSurname.Text}','{textBoxStreetNsme.Text}', '{textBoxBuildingNum.Text}','{textBoxfloorNum.Text}','{textBoxRoomNumber.Text}','{login}')");
                loadItems();
            }
            catch (Exception ex)
            { MessageBox.Show("Invalid data" + ex.Message); }
            clearData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (id == "")
                    return;
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                DBFunc.sendRequest($"DELETE FROM data WHERE id='{id}'");
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            clearData();
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                    return;
                
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                
                Adress adr = new Adress(textBoxSurname.Text, textBoxStreetNsme.Text, textBoxBuildingNum.Text, textBoxfloorNum.Text, textBoxRoomNumber.Text);
                /*row.Cells[1].Value = textBoxSurname.Text;
                row.Cells[2].Value = textBoxStreetNsme.Text;
                row.Cells[3].Value = textBoxBuildingNum.Text;
                row.Cells[4].Value = textBoxfloorNum.Text;
                row.Cells[5].Value = textBoxRoomNumber.Text;
                */
                string id = row.Cells[0].Value.ToString();
                if (id == "")
                    return;
                DBFunc.sendRequest($"UPDATE data set surname='{textBoxSurname.Text}', street_name='{textBoxStreetNsme.Text}', building_num='{textBoxBuildingNum.Text}', floor_num='{textBoxfloorNum.Text}', room_num='{textBoxRoomNumber.Text}' where id='{id}'");
                loadItems();
            }
            catch (Exception ex)
            { MessageBox.Show("Invalid data"); }
            clearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                    return;
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textBoxSurname.Text = row.Cells[1].Value.ToString();
                textBoxStreetNsme.Text = row.Cells[2].Value.ToString();
                textBoxBuildingNum.Text = row.Cells[3].Value.ToString();
                textBoxfloorNum.Text = row.Cells[4].Value.ToString();
                textBoxRoomNumber.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show("Invalid data"); }
        }
    }
}
