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
    public partial class frm_Quantrivien_Tra : Form
    {
        public frm_Quantrivien_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quantrivien_Tra_Load(object sender, EventArgs e)
        {
            hienthidulieudatagridview();
        }

        private void dgv_hienthidanhsachnguoidung_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachnguoidung_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                cb_loainguoidung_tra.Text = dgv_hienthidanhsachnguoidung_tra.Rows[dongchon].Cells["LoaiNguoiDung"].Value.ToString();
                tb_tendangnhap_tra.Text = dgv_hienthidanhsachnguoidung_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
                tb_matkhau_tra.Text = dgv_hienthidanhsachnguoidung_tra.Rows[dongchon].Cells["MatKhau"].Value.ToString();
            }
        }

        private void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from nguoi_dung", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_hienthidanhsachnguoidung_tra.DataSource = dt;
        }
        void XoaSinhVien(string tendangnhap)
        {
            string masv=string.Empty;
            SqlCommand cmd = new SqlCommand("select MaSinhVien from sinh_vien where TenDangNhap='" + tendangnhap + "'", frm_DangNhap_Tra.con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read()) masv = dt["MaSinhVien"].ToString();
            dt.Close();
            cmd = new SqlCommand("delete from diem where MaSinhVien='"+masv+"'", frm_DangNhap_Tra.con);
            cmd.ExecuteNonQuery();
            ///
            SqlCommand cmd1 = new SqlCommand("delete from sinh_vien where TenDangNhap=@TenDangNhap", frm_DangNhap_Tra.con);
            cmd1.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
            cmd1.ExecuteNonQuery();
        }
        void XoaGiaoVien(string tendangnhap)
        {
            string magv = string.Empty;
            SqlCommand cmd = new SqlCommand("select MagiaoVien from giao_vien where TenDangNhap='" + tendangnhap + "'", frm_DangNhap_Tra.con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read()) magv = dt["MaGiaoVien"].ToString();
            dt.Close();
            cmd = new SqlCommand("delete from lop_hoc_phan where MaGiaoVien='" + magv + "'", frm_DangNhap_Tra.con);
            cmd.ExecuteNonQuery();
            //
            SqlCommand cmd1 = new SqlCommand("delete from giao_vien where TenDangNhap=@TenDangNhap", frm_DangNhap_Tra.con);
            cmd1.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
            cmd1.ExecuteNonQuery();
        }

        private void pb_themnguoidung_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from nguoi_dung where TenDangNhap = '" + tb_tendangnhap_tra.Text + "' ", frm_DangNhap_Tra.con);
            if (cmd.ExecuteScalar() == null)
            {
                SqlCommand cmd1 = new SqlCommand(
                "insert into nguoi_dung(TenDangNhap,MatKhau,LoaiNguoiDung)" +
                "values(@TenDangNhap,@MatKhau,@LoaiNguoiDung)", frm_DangNhap_Tra.con);
                cmd1.Parameters.AddWithValue("@TenDangNhap", tb_tendangnhap_tra.Text);
                cmd1.Parameters.AddWithValue("@MatKhau", tb_matkhau_tra.Text);
                cmd1.Parameters.AddWithValue("@LoaiNguoiDung", cb_loainguoidung_tra.Text);
                if (cmd1.ExecuteNonQuery() > 0) MessageBox.Show("Thêm người dùng thành công");
                else MessageBox.Show("Thêm người dùng thất bại");
            }
            else MessageBox.Show("Tên đăng nhập đã tồn tại!");
            hienthidulieudatagridview();
        }

        private void pb_xoanguoidung_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachnguoidung_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                string tendangnhap = dgv_hienthidanhsachnguoidung_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
                XoaSinhVien(tendangnhap);
                //
                XoaGiaoVien(tendangnhap);
                //
                SqlCommand cmd = new SqlCommand("delete from nguoi_dung where TenDangNhap=@TenDangNhap", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
                //
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa người dùng thành công");
                else MessageBox.Show("Xóa người dùng thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_suanguoidung_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hienthidanhsachnguoidung_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
                "Update nguoi_dung set MatKhau=@MatKhau,LoaiNguoiDung=@LoaiNguoiDung where TenDangNhap=@TenDangNhapcu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MatKhau", tb_matkhau_tra.Text);
                cmd.Parameters.AddWithValue("@LoaiNguoiDung", cb_loainguoidung_tra.Text);
                cmd.Parameters.AddWithValue("@TenDangNhapcu", dgv_hienthidanhsachnguoidung_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_menuquanly_tra_Click(object sender, EventArgs e)
        {
            Hide();
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
        }
    }
}
