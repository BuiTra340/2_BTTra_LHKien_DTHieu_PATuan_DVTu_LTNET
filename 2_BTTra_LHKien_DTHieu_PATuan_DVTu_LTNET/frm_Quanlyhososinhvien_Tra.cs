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
    public partial class frm_Quanlyhososinhvien_Tra : Form
    {
        public frm_Quanlyhososinhvien_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quanlyhososinhvien_Tra_Load(object sender, EventArgs e)
        {
            if(frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
                frm_DangNhap_Tra.loainguoidung.Equals("Giáo viên"))
            {
                DisableObject();
            }
            hienthidulieudatagridview();
        }
        void DisableObject()
        {
            tb_masinhvien_tra.Enabled = false;
            tb_hodem_tra.Enabled = false;
            tb_ten_tra.Enabled = false;
            dtp_ngaysinh_tra.Enabled = false;
            tb_gioitinh_tra.Enabled = false;
            tb_quequan_tra.Enabled = false;
            tb_sodienthoai_tra.Enabled = false;
            tb_tendangnhap_tra.Enabled = false;
            cb_malop_tra.Enabled = false;
            pb_themsinhvien_tra.Enabled = false;
            pb_suasinhvien_tra.Enabled = false;
            pb_xoasinhvien_tra.Enabled = false;
            pb_sapxepsinhvien_tra.Enabled = false;
        }

        private void dgv_hososinhvien_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_hososinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_masinhvien_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString();
                tb_hodem_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["HoDem"].Value.ToString();
                tb_ten_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["Ten"].Value.ToString();
                dtp_ngaysinh_tra.Value = DateTime.Parse(dgv_hososinhvien_tra.Rows[dongchon].Cells["NgaySinh"].Value.ToString());
                tb_gioitinh_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["GioiTinh"].Value.ToString();
                tb_quequan_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["QueQuan"].Value.ToString();
                tb_sodienthoai_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["SoDienThoai"].Value.ToString();
                cb_malop_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["MaLop"].Value.ToString();
                tb_tendangnhap_tra.Text = dgv_hososinhvien_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
            }
        }
        void ThemNguoiDungVaSinhVien()
        {
            SqlCommand cmd1 = new SqlCommand(
                "insert into nguoi_dung(TenDangNhap,MatKhau,LoaiNguoiDung)" +
                "values(@TenDangNhap,@MatKhau,@LoaiNguoiDung)", frm_DangNhap_Tra.con);
            cmd1.Parameters.AddWithValue("@TenDangNhap", tb_tendangnhap_tra.Text);
            cmd1.Parameters.AddWithValue("@MatKhau", "1111");
            cmd1.Parameters.AddWithValue("@LoaiNguoiDung", "Sinh viên");
            if (cmd1.ExecuteNonQuery() > 0) 
            ThemSinhVien();
        }
        void ThemSinhVien()
        {
            SqlCommand cmd = new SqlCommand(
                "insert into sinh_vien(MaSinhVien,HoDem,Ten,NgaySinh,GioiTinh,QueQuan,SoDienThoai,MaLop,TenDangNhap)" +
                "values(@MaSinhVien,@HoDem,@Ten,@NgaySinh,@GioiTinh,@QueQuan,@SoDienThoai,@MaLop,@TenDangNhap)", frm_DangNhap_Tra.con);
            cmd.Parameters.AddWithValue("@MaSinhVien", tb_masinhvien_tra.Text);
            cmd.Parameters.AddWithValue("@HoDem", tb_hodem_tra.Text);
            cmd.Parameters.AddWithValue("@Ten", tb_ten_tra.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh_tra.Value);
            cmd.Parameters.AddWithValue("@GioiTinh", tb_gioitinh_tra.Text);
            cmd.Parameters.AddWithValue("@QueQuan", tb_quequan_tra.Text);
            cmd.Parameters.AddWithValue("@SoDienThoai", tb_sodienthoai_tra.Text);
            cmd.Parameters.AddWithValue("@MaLop", cb_malop_tra.Text);
            cmd.Parameters.AddWithValue("@TenDangNhap", tb_tendangnhap_tra.Text);
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm sinh viên thành công");
            else MessageBox.Show("Thêm sinh viên thất bại");
            ThemSinhVienVaoDiem();
        }
        void ThemSinhVienVaoDiem()
        {
            SqlCommand cmd1;
            cmd1 = new SqlCommand("select MaMonHoc from lop_hoc_phan join sinh_vien on sinh_vien.MaLop = lop_hoc_phan.MaLop" +
                " where sinh_vien.MaSinhVien = '" + tb_masinhvien_tra.Text + "'", frm_DangNhap_Tra.con);
            SqlDataReader dt = cmd1.ExecuteReader();
            string[] mamonhoc = new string[99];
            int i = 0;
            while(dt.Read())
            {
                mamonhoc[i] = dt["MaMonHoc"].ToString();
                i++;
            }
            dt.Close();
            
            for (int j=0;j<i;j++)
            {
                cmd1 = new SqlCommand(
                   "insert into diem(MaSinhVien,MaMonHoc)" +
                   "values(@MaSinhVien,@MaMonHoc)", frm_DangNhap_Tra.con);
                cmd1.Parameters.AddWithValue("@MaSinhVien", tb_masinhvien_tra.Text);
                cmd1.Parameters.AddWithValue("@MaMonHoc", mamonhoc[j]);
                cmd1.ExecuteNonQuery();
            }
        }
        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from sinh_vien", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_hososinhvien_tra.DataSource = dt;
            //
            SqlCommand cmd1 = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_malop_tra.DataSource = dt1;
            cb_malop_tra.DisplayMember = "MaLop";
            cb_malop_tra.ValueMember = "MaLop";
        }

        private void pb_timsinhvien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from sinh_vien where Ten like N'%" + tb_timsinhvien_tra.Text + "' or MaSinhVien like N'%" + tb_timsinhvien_tra.Text + "%'", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_hososinhvien_tra.DataSource = dt;
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }

        private void pb_themsinhvien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select * from sinh_vien where MaSinhVien ='" + tb_masinhvien_tra.Text + "' or TenDangNhap = '" + tb_tendangnhap_tra.Text + "' ", frm_DangNhap_Tra.con);
            if (cmd1.ExecuteScalar() == null)
            {
                SqlCommand cmd2 = new SqlCommand("select * from nguoi_dung where TenDangNhap='" + tb_tendangnhap_tra.Text + "'", frm_DangNhap_Tra.con);
                if (cmd2.ExecuteScalar() == null)
                {
                    ThemNguoiDungVaSinhVien();
                }
                else
                {
                    ThemSinhVien();
                }

            }
            else MessageBox.Show("Mã sinh viên hoặc tên đăng nhập đã tồn tại");
            hienthidulieudatagridview();
        }

        private void pb_suasinhvien_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hososinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
               "Update sinh_vien set HoDem=@HoDem,Ten=@Ten,NgaySinh=@NgaySinh, " +
               "GioiTinh=@GioiTinh,QueQuan=@QueQuan,SoDienThoai=@SoDienThoai,MaLop=@MaLop where MaSinhVien=@MaSVcu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@HoDem", tb_hodem_tra.Text);
                cmd.Parameters.AddWithValue("@Ten", tb_ten_tra.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh_tra.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", tb_gioitinh_tra.Text);
                cmd.Parameters.AddWithValue("@QueQuan", tb_quequan_tra.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", tb_sodienthoai_tra.Text);
                cmd.Parameters.AddWithValue("@MaLop", cb_malop_tra.Text);
                cmd.Parameters.AddWithValue("@MaSVcu", dgv_hososinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_xoasinhvien_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_hososinhvien_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                string tendangnhap = dgv_hososinhvien_tra.Rows[dongchon].Cells["TenDangNhap"].Value.ToString();
                SqlCommand cmd = new SqlCommand("delete from diem where MaSinhVien=@MaSV", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaSV", dgv_hososinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString());
                cmd.ExecuteNonQuery();
                ///
                SqlCommand cmd1 = new SqlCommand("delete from sinh_vien where MaSinhVien=@MaSV", frm_DangNhap_Tra.con);
                cmd1.Parameters.AddWithValue("@MaSV", dgv_hososinhvien_tra.Rows[dongchon].Cells["MaSinhVien"].Value.ToString());
                if (cmd1.ExecuteNonQuery() > 0) MessageBox.Show("Xóa sinh viên thành công");
                else MessageBox.Show("Xóa sinh viên thất bại");
                //
                cmd = new SqlCommand("delete from nguoi_dung where TenDangNhap=@TenDangNhap", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
                cmd.ExecuteNonQuery();
                hienthidulieudatagridview();
            }
        }

        private void pb_sapxepsinhvien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from sinh_vien order by Ten asc ", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_hososinhvien_tra.DataSource = dt;
        }
    }
}
