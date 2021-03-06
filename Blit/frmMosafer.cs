﻿using ClearClass;
using Connection_Class;
using System;
using System.Windows.Forms;

namespace Blit
{
    public partial class frmMosafer : DevComponents.DotNetBar.Office2007Form
    {
        Connection_Query query = new Connection_Query();

        public frmMosafer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            query.OpenConection();
            try
            {
                query.ExecuteQueries(string.Format("insert into tblMosafer values('{0}','{1}','{2}','{3}','{4}')", txtFName.Text, txtLName.Text, cmbGender.Text, txtSen.Text, txtTel.Text));
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls.ClearTextBoxes(this);
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            query.CloseConnection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query.OpenConection();
            try
            {
                query.ExecuteQueries("delete from tblMosafer where ID=" + txtCode.Text);
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls.ClearTextBoxes(this);
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            query.CloseConnection();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            query.OpenConection();
            try
            {
                query.ExecuteQueries("Update tblMosafer set FName='" + txtFName.Text + "',LName='" + txtLName.Text + "',Gender='" + cmbGender.Text + "',Sen='" + txtSen.Text + "',Tel='" + txtTel.Text + "' where ID=" + txtCode.Text);
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls.ClearTextBoxes(this);
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            query.CloseConnection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query.OpenConection();
            try
            {
                var dr = query.DataReader("select * from tblMosafer where ID=" + txtCode.Text);

                if (dr.Read())
                {
                    txtCode.Text = dr["ID"].ToString();
                    txtFName.Text = dr["FName"].ToString();
                    txtLName.Text = dr["LName"].ToString();
                    cmbGender.Text = dr["Gender"].ToString();
                    txtSen.Text = dr["Sen"].ToString();
                    txtTel.Text = dr["Tel"].ToString();
                }
                else
                {
                    MessageBox.Show("اطلاعاتی برای این کد پیدا نشد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearControls.ClearTextBoxes(this);
                    txtCode.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("در هنگام اتصال به بانک اطلاعاتی خطایی رخ داده است ، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            query.CloseConnection();
        }
    }
}