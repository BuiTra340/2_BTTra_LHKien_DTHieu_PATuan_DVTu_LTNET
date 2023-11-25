using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    public partial class frm_DanhsachdiemExcel_tra : Form
    {
        public frm_DanhsachdiemExcel_tra()
        {
            InitializeComponent();
        }

        private void frm_DanhsachdiemExcel_tra_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            cb_chonlophoc_tra.DataSource = dt;
            cb_chonlophoc_tra.DisplayMember = "TenLop";
            cb_chonlophoc_tra.ValueMember = "MaLop";
            //
            cmd = new SqlCommand("select * from mon_hoc", frm_DangNhap_Tra.con);
            da = new SqlDataAdapter(cmd);
            dt = new System.Data.DataTable();
            da.Fill(dt);
            cb_chonmonhoc_tra.DataSource = dt;
            cb_chonmonhoc_tra.DisplayMember = "TenMonHoc";
            cb_chonmonhoc_tra.ValueMember = "MaMonHoc";
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

        private void pb_hienthi_tra_Click(object sender, EventArgs e)
        {
            string maLopHoc = cb_chonlophoc_tra.SelectedValue.ToString();
            string maMonHoc = cb_chonmonhoc_tra.SelectedValue.ToString();
            string query = "select sinh_vien.MaSinhVien,sinh_vien.HoDem,sinh_vien.Ten,diem.DiemChuyenCan," +
                "diem.DiemHeSo1,diem.DiemHeSo2_1,diem.DiemHeSo2_2,diem.DiemQuaTrinh,diem.DiemThi,diem.DiemHocPhan " +
                "from sinh_vien join diem on sinh_vien.MaSinhVien = diem.MaSinhVien " +
                "where sinh_vien.MaLop ='" + maLopHoc + "' and diem.MaMonHoc = '" + maMonHoc + "' ";
            SqlCommand cmd = new SqlCommand(query, frm_DangNhap_Tra.con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            System.Data.DataTable dt1 = new System.Data.DataTable();
            da1.Fill(dt1);
            dgv_DanhsachdiemExcel_tra.DataSource = dt1;
        }

        private void pb_xuatexcel_tra_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_DanhsachdiemExcel_tra, @"D:\", "Danhsachdiemsinhvien");
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
