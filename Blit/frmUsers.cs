﻿using ClearClass;
using Connection_Class;
using System;
using System.Windows.Forms;

namespace Blit
{
    public partial class frmUsers : DevComponents.DotNetBar.Office2007Form
    {
        Connection_Query query = new Connection_Query();

        public frmUsers()
        {
            InitializeComponent();
        }

        void Display()
        {
            dgvUsers.DataSource = query.ShowData("Select * from tblUsers");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                query.OpenConection();
                query.ExecuteQueries(string.Format("insert into tblusers values('{0}','{1}')", txtUserName.Text, txtPassword.Text));
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls.ClearTextBoxes(this);
                Display();
                query.CloseConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvUsers.SelectedCells[0].Value);//id cell entekhab shode
                query.OpenConection();
                query.ExecuteQueries("Delete from tblUsers where ID=" + x);
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}