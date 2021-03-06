﻿using Connection_Class;
using Stimulsoft.Report;
using System;
using System.Windows.Forms;

namespace Blit
{
    public partial class frmListCitys : DevComponents.DotNetBar.Office2007Form
    {
        Connection_Query query = new Connection_Query();
        string NameAgency, TelA, AddressA;

        public frmListCitys()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query.OpenConection();
            try
            {
                int x = Convert.ToInt32(dgvCitys.SelectedCells[0].Value);
                query.ExecuteQueries("delete from tblCity where ID=" + x);
                MessageBox.Show("عملیات با موفقیت انجام شد", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است، مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            query.CloseConnection();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport report = new StiReport();//sakhte Shey
                report.Load("Report/rptCity.mrt");//masir file MRT report
                report.Compile();
                //ersal Variable ha b Stimulsoft
                report["strNameAgency"] = NameAgency;
                report["strTelA"] = TelA;
                report["strAddressA"] = AddressA;
                report.ShowWithRibbonGUI();
            }
            catch (Exception)
            {
                MessageBox.Show("در هنگام گزارش گیری خطایی رخ داده است لطفا مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Display()
        {
            query.OpenConection();
            try
            {
                dgvCitys.DataSource = query.ShowData("select * from tblCity");

                var dr = query.DataReader("select * from tblSetting");
                if (dr.Read())
                {
                    NameAgency = dr["NameAgency"].ToString();
                    TelA = dr["TelA"].ToString();
                    AddressA = dr["AddressA"].ToString();
                }
                else
                {
                    MessageBox.Show("ابتدا در بخش تنظیمات مشخصات آژانس را وارد کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new frmSetting().ShowDialog();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("در اتصال به پایگاه داده خطایی رخ داده است ، لطفا مجددا تلاش کنید", "Blit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            query.CloseConnection();
        }
        private void frmListCitys_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}