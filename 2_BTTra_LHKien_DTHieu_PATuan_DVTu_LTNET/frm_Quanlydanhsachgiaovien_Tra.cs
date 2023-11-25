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
    public partial class frm_Quanlydanhsachgiaovien_Tra : Form
    {
        public frm_Quanlydanhsachgiaovien_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quanlydanhsachgiaovien_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
                frm_DangNhap_Tra.loainguoidung.Equals("Phòng đào tạo")) DisableObject();
            hienthidulieudatagridview();
        }

        private void DisableObject()
        {
            pb_suagiaovien_tra.Enabled = false;
            pb_themgiaovien_tra.Enabled=false;
            pb_suagiaovien_tra.Enabled = false;
            pb_xoagiaovien_tra.Enabled = false;
            tb_hotengiaovien_tra.Enabled = false;
            tb_magiaovien_tra.Enabled = false;
            tb_tendangnhap_tra.Enabled = false;
            dtp_ngaysinh_tra.Enabled = false;
            cb_makhoa_tra.Enabled = false;
        }

        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from giao_vien", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_danhsachgiaovien_tra.DataSource = dt;
            //
            SqlCommand cmd1 = new SqlCommand("select * from khoa", frm_DangNhap_Tra.con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_makhoa_tra.DataSource = dt1;
            cb_makhoa_tra.DisplayMember = "MaKhoa";
            cb_makhoa_tra.ValueMember = "MaKhoa";
        }
        void ThemNguoiDungVaGiaoVien()
        {
            SqlCommand cmd1 = new SqlCommand(
                "insert into nguoi_dung(TenDangNhap,MatKhau,LoaiNguoiDung)" +
                "values(@TenDangNhap,@MatKhau,@LoaiNguoiDung)", frm_DangNhap_Tra.con);
            cmd1.Parameters.AddWithValue("@TenDangNhap", tb_tendangnhap_tra.Text);
            cmd1.Parameters.AddWithValue("@MatKhau", "1111");
            cmd1.Parameters.AddWithValue("@LoaiNguoiDung", "Giáo viên");
            if (cmd1.ExecuteNonQuery() > 0)
                ThemGiaoVien();
        }
        void ThemGiaoVien()
        {
            SqlCommand cmd = new SqlCommand(
                "insert into giao_vien(MaGiaoVien,HoTen,NgaySinh,MaKhoa,TenDangNhap)" +
                "values(@MaGiaoVien,@HoTen,@NgaySinh,@MaKhoa,@TenDangNhap)", frm_DangNhap_Tra.con);
            cmd.Parameters.AddWithValue("@MaGiaoVien", tb_magiaovien_tra.Text);
            cmd.Parameters.AddWithValue("@HoTen", tb_hotengiaovien_tra.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh_tra.Value);
            cmd.Parameters.AddWithValue("@MaKhoa", cb_makhoa_tra.Text);
            cmd.Parameters.AddWithValue("@TenDangNhap", tb_tendangnhap_tra.Text);
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm giáo viên thành công");
            else MessageBox.Show("Thêm giáo viên thất bại");
        }

        private void dgv_danhsachgiaovien_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_danhsachgiaovien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_magiaovien_tra.Text = dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["MaGiaoVien"].Value.ToString();
                tb_hotengiaovien_tra.Text = dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["HoTen"].Value.ToString();
                cb_makhoa_tra.Text = dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["MaKhoa"].Value.ToString();
                dtp_ngaysinh_tra.Value = DateTime.Parse(dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["NgaySinh"].Value.ToString());
                tb_tendangnhap_tra.Text = dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
            }
        }

        private void pb_timgiaovien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from giao_vien where HoTen like N'%" + tb_timgiaovien_tra.Text + "' or MaGiaoVien like N'%" + tb_timgiaovien_tra.Text + "%'", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_danhsachgiaovien_tra.DataSource = dt;
        }

        private void pb_themgiaovien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select * from giao_vien where MaGiaoVien ='" + tb_magiaovien_tra.Text + "' or TenDangNhap = '" + tb_tendangnhap_tra.Text + "' ", frm_DangNhap_Tra.con);
            if (cmd1.ExecuteScalar() == null)
            {
                SqlCommand cmd2 = new SqlCommand("select * from nguoi_dung where TenDangNhap='" + tb_tendangnhap_tra.Text + "'", frm_DangNhap_Tra.con);
                if (cmd2.ExecuteScalar() == null)
                {
                    ThemNguoiDungVaGiaoVien();
                }
                else
                {
                    ThemGiaoVien();
                }
            }
            else MessageBox.Show("Mã giáo viên hoặc tên đăng nhập đã tồn tại");
            hienthidulieudatagridview();
        }

        private void pb_suagiaovien_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_danhsachgiaovien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
               "Update giao_vien set HoTen=@HoTen,NgaySinh=@NgaySinh, " +
               "MaKhoa=@MaKhoa where MaGiaoVien=@MaGVcu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@HoTen", tb_hotengiaovien_tra.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh_tra.Value);
                cmd.Parameters.AddWithValue("@MaKhoa", cb_makhoa_tra.Text);
                cmd.Parameters.AddWithValue("@MaGVcu", dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["MaGiaovien"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_xoagiaovien_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_danhsachgiaovien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                string tendangnhap = dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
                SqlCommand cmd = new SqlCommand("delete from lop_hoc_phan where MaGiaoVien=@MaGiaoVien", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaGiaoVien", dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["MaGiaoVien"].Value.ToString());
                cmd.ExecuteNonQuery();
                ///
                SqlCommand cmd1 = new SqlCommand("delete from giao_vien where MaGiaoVien=@MaGiaoVien", frm_DangNhap_Tra.con);
                cmd1.Parameters.AddWithValue("@MaGiaoVien", dgv_danhsachgiaovien_tra.Rows[dongchon].Cells["MaGiaoVien"].Value.ToString());
                if (cmd1.ExecuteNonQuery() > 0) MessageBox.Show("Xóa giáo viên thành công");
                else MessageBox.Show("Xóa giáo viên thất bại");
                //
                cmd = new SqlCommand("delete from nguoi_dung where TenDangNhap=@TenDangNhap", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
                cmd.ExecuteNonQuery();
                hienthidulieudatagridview();
            }
        }
        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
