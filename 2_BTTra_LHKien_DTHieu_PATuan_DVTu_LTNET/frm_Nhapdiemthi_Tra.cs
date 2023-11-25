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

namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    public partial class frm_Nhapdiemthi_Tra : Form
    {
        bool daChonLop=false;
        bool daChonMonHoc = false;
        public frm_Nhapdiemthi_Tra()
        {
            InitializeComponent();
        }

        private void cb_chonlophoc_tra_SelectedIndexChanged(object sender, EventArgs e)
        {
            daChonLop = true;
            if (daChonMonHoc)
            {
                string maLopHoc = cb_chonlophoc_tra.SelectedValue.ToString();
                string maMonHoc = cb_chonmonhoc_tra.SelectedValue.ToString();
                string query = "select sinh_vien.*,mon_hoc.TenMonHoc,mon_hoc.SoTinChi,diem.DiemChuyenCan,diem.DiemHeSo1,diem.DiemHeSo2_1," +
                    "diem.DiemHeSo2_2,diem.DiemQuaTrinh,diem.DiemThi,diem.DiemHocPhan from sinh_vien join diem" +
                    " on diem.MaSinhVien = sinh_vien.MaSinhVien join mon_hoc on mon_hoc.MaMonHoc = diem.MaMonHoc" +
                    " where sinh_vien.MaLop ='" + maLopHoc + "' and diem.MaMonHoc = '" + maMonHoc + "' ";
                SqlCommand cmd = new SqlCommand(query, frm_DangNhap_Tra.con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgv_hienthidanhsachsinhvien_tra.DataSource = dt1;

            }
        }

        private void cb_chonmonhoc_tra_SelectedIndexChanged(object sender, EventArgs e)
        {
            daChonMonHoc = true;
            if (daChonLop)
            {
                string maLopHoc = cb_chonlophoc_tra.SelectedValue.ToString();
                string maMonHoc = cb_chonmonhoc_tra.SelectedValue.ToString();
                string query = "select sinh_vien.*,mon_hoc.TenMonHoc,mon_hoc.SoTinChi,diem.DiemChuyenCan,diem.DiemHeSo1,diem.DiemHeSo2_1," +
                    "diem.DiemHeSo2_2,diem.DiemQuaTrinh,diem.DiemThi,diem.DiemHocPhan from sinh_vien join diem" +
                    " on diem.MaSinhVien = sinh_vien.MaSinhVien join mon_hoc on mon_hoc.MaMonHoc = diem.MaMonHoc" +
                    " where sinh_vien.MaLop ='" + maLopHoc + "' and diem.MaMonHoc = '" + maMonHoc + "' ";
                SqlCommand cmd = new SqlCommand(query, frm_DangNhap_Tra.con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgv_hienthidanhsachsinhvien_tra.DataSource = dt1;

            }
        }

        private void dgv_hienthidanhsachsinhvien_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachsinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_diemthi_tra.Text = dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemThi"].Value.ToString();
            }
        }

        private void frm_Nhapdiemthi_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
                frm_DangNhap_Tra.loainguoidung.Equals("Phòng đào tạo"))
            {
                DisableObject();
            }
            SqlCommand cmd = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_chonlophoc_tra.DataSource = dt;
            cb_chonlophoc_tra.DisplayMember = "TenLop";
            cb_chonlophoc_tra.ValueMember = "MaLop";
            //
            cmd = new SqlCommand("select * from mon_hoc", frm_DangNhap_Tra.con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            cb_chonmonhoc_tra.DataSource = dt;
            cb_chonmonhoc_tra.DisplayMember = "TenMonHoc";
            cb_chonmonhoc_tra.ValueMember = "MaMonHoc";
        }
        void DisableObject()
        {
            pb_nhapdiemthi_tra.Enabled = false;
            tb_diemthi_tra.Enabled=false;
        }

        private void b_nhapdiemthi_tra_Click(object sender, EventArgs e)
        {
            
        }

        private void b_quaylai_tra_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_nhapdiemthi_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachsinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                float diemThi = float.Parse(tb_diemthi_tra.Text);
                float diemHocPhan = float.Parse(dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemQuaTrinh"].Value.ToString()) * .4f
                    + diemThi * .6f;
                diemHocPhan = (float)Math.Round(diemHocPhan, 2);
                //
                SqlCommand cmd = new SqlCommand(
               "Update diem set DiemThi=@DiemThi,DiemHocPhan=@DiemHocPhan where MaSinhVien=@MaSinhViencu and MaMonHoc=@MaMonHoc", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@DiemThi", diemThi);
                cmd.Parameters.AddWithValue("@DiemHocPhan", diemHocPhan);
                cmd.Parameters.AddWithValue("@MaSinhViencu", dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString());
                cmd.Parameters.AddWithValue("@MaMonHoc", cb_chonmonhoc_tra.SelectedValue);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Nhập điểm thi thành công");
                else MessageBox.Show("Nhập điểm thi thất bại");
            }
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
        }
    }
}
