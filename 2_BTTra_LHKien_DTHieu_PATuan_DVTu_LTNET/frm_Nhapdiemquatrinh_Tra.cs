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
    public partial class frm_Nhapdiemquatrinh_Tra : Form
    {
        bool daChonLop = false;
        bool daChonMonHoc = false;
        public frm_Nhapdiemquatrinh_Tra()
        {
            InitializeComponent();
        }

        private void cb_chonlophoc_tra_SelectedIndexChanged(object sender, EventArgs e)
        {
            daChonLop=true;
            if(daChonMonHoc)
            {
                string maLopHoc = cb_chonlophoc_tra.SelectedValue.ToString();
                string maMonHoc = cb_chonmonhoc_tra.SelectedValue.ToString();
                string query = "select sinh_vien.*,mon_hoc.TenMonHoc,mon_hoc.SoTinChi,diem.DiemChuyenCan,diem.DiemHeSo1,diem.DiemHeSo2_1," +
                    "diem.DiemHeSo2_2,diem.DiemQuaTrinh from sinh_vien join diem" +
                    " on diem.MaSinhVien = sinh_vien.MaSinhVien join mon_hoc on mon_hoc.MaMonHoc = diem.MaMonHoc" +
                    " where sinh_vien.MaLop ='" + maLopHoc + "' and diem.MaMonHoc = '" + maMonHoc + "' ";
                SqlCommand cmd = new SqlCommand(query, frm_DangNhap_Tra.con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgv_hienthidanhsachsinhvien_tra.DataSource = dt1;

            }
        }

        private void frm_Nhapdiemquatrinh_Tra_Load(object sender, EventArgs e)
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
            pb_nhapdiemquatrinh_tra.Enabled = false;
            tb_diemchuyencan_tra.Enabled = false;
            tb_diemheso1_tra.Enabled = false;
            tb_diemheso2thuhai_tra.Enabled = false;
            tb_diemheso2thunhat_tra.Enabled = false;
        }

        private void cb_chonmonhoc_tra_SelectedIndexChanged(object sender, EventArgs e)
        {
            daChonMonHoc = true;
            if (daChonLop)
            {
                string maLopHoc = cb_chonlophoc_tra.SelectedValue.ToString();
                string maMonHoc = cb_chonmonhoc_tra.SelectedValue.ToString();
                string query = "select sinh_vien.*,mon_hoc.TenMonHoc,mon_hoc.SoTinChi,diem.DiemChuyenCan,diem.DiemHeSo1,diem.DiemHeSo2_1," +
                    "diem.DiemHeSo2_2,diem.DiemQuaTrinh from sinh_vien join diem" +
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
            if(dongchon >=0)
            {
                tb_diemchuyencan_tra.Text = dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemChuyenCan"].Value.ToString();
                tb_diemheso1_tra.Text = dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemHeSo1"].Value.ToString();
                tb_diemheso2thunhat_tra.Text = dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemHeSo2_1"].Value.ToString();
                tb_diemheso2thuhai_tra.Text = dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["DiemHeSo2_2"].Value.ToString();
            }
        }

        private void pb_nhapdiemquatrinh_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachsinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                float diemChuyenCan = float.Parse(tb_diemchuyencan_tra.Text);
                float diemHeSo1 = float.Parse(tb_diemheso1_tra.Text);
                float diemHeSo2_1 = float.Parse(tb_diemheso2thunhat_tra.Text);
                float diemHeSo2_2 = float.Parse(tb_diemheso2thuhai_tra.Text);
                int soTinChi = int.Parse(dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["SoTinChi"].Value.ToString());
                float diemQuaTrinh = (float)Math.Round((diemChuyenCan * soTinChi + diemHeSo1 + diemHeSo2_1 * 2 + diemHeSo2_2 * 2) / (soTinChi + 5), 2);
                //
                SqlCommand cmd = new SqlCommand(
               "Update diem set DiemChuyenCan=@DiemChuyenCan,DiemHeSo1=@DiemHeSo1,DiemHeSo2_1=@DiemHeSo2_1, " +
               "DiemHeSo2_2=@DiemHeSo2_2,DiemQuaTrinh=@DiemQuaTrinh where MaSinhVien=@MaSinhViencu and MaMonHoc=@MaMonHoc", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@DiemChuyenCan", diemChuyenCan);
                cmd.Parameters.AddWithValue("@DiemHeSo1", diemHeSo1);
                cmd.Parameters.AddWithValue("@DiemHeSo2_1", diemHeSo2_1);
                cmd.Parameters.AddWithValue("@DiemHeSo2_2", diemHeSo2_2);
                cmd.Parameters.AddWithValue("@DiemQuaTrinh", diemQuaTrinh);
                cmd.Parameters.AddWithValue("@MaSinhViencu", dgv_hienthidanhsachsinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString());
                cmd.Parameters.AddWithValue("@MaMonHoc", cb_chonmonhoc_tra.SelectedValue);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Nhập điểm thành công");
                else MessageBox.Show("Nhập điểm thất bại");
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
