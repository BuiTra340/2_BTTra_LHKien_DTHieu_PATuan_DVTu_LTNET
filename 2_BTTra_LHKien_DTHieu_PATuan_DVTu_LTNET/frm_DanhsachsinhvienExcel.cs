using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    public partial class frm_DanhsachsinhvienExcel : Form
    {
        public frm_DanhsachsinhvienExcel()
        {
            InitializeComponent();
        }

        private void frm_DanhsachsinhvienExcel_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            cb_chonlop_tra.DataSource = dt;
            cb_chonlop_tra.DisplayMember = "TenLop";
            cb_chonlop_tra.ValueMember = "MaLop";
        }
        private void exportExcel(DataGridView dgv, string path, string fileName)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i <= dgv.Columns.Count; i++)
            {
                obj.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(path + fileName + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
            //obj.Columns.AutoFit();
            //obj.Visible = true;
        }

        private void pb_hienthidssv_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from sinh_vien where MaLop='" + cb_chonlop_tra.SelectedValue + "'", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dgv_DssvExcel_tra.DataSource = dt;
        }

        private void pb_xuatexcel_tra_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_DssvExcel_tra, @"D:\", "Danhsachsinhvien");
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
