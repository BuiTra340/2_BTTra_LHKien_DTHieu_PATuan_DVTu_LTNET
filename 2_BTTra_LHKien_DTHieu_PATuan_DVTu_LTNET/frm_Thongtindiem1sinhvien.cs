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
using Microsoft.Reporting.WinForms;

namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    public partial class frm_Thongtindiem1sinhvien : Form
    {
        public frm_Thongtindiem1sinhvien()
        {
            InitializeComponent();
        }

        private void frm_Thongtindiem1sinhvien_Load(object sender, EventArgs e)
        {
            
        }
        DataSet ReadDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, frm_DangNhap_Tra.con);
            adapter.Fill(dataSet);
            return dataSet;
        }
        private void pb_hienthireport_tra_Click(object sender, EventArgs e)
        {
            DataSet ds = ReadDataSet("select * from diem where MaSinhVien='" + tb_masinhvien_tra.Text + "'");
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.ReportPath = "Thongtinbangdiem.rdlc";
            //reportViewer1.LocalReport.ReportEmbeddedResource = "diem.Thongtinbangdiem.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "diem";
                rds.Value = ds.Tables[0];
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
