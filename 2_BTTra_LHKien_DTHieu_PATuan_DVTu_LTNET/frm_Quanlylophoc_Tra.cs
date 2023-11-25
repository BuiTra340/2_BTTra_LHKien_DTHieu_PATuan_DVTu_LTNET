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
    public partial class frm_Quanlylophoc_Tra : Form
    {
        public frm_Quanlylophoc_Tra()
        {
            InitializeComponent();
        }
        private void frm_Quanlylophoc_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
                frm_DangNhap_Tra.loainguoidung.Equals("Giáo viên")) DisableObject();
            hienthidulieudatagridview();
        }

        private void DisableObject()
        {
            tb_hedaotao_tra.Enabled = false;
            tb_khoahoc_tra.Enabled = false;
            tb_malop_tra.Enabled=false;
            tb_namnhaphoc_tra.Enabled=false;
            tb_tenlop_tra.Enabled=false;
            cb_makhoa_tra.Enabled=false;
            pb_sapxeplop_tra.Enabled=false;
            pb_sualophoc_tra.Enabled=false;
            pb_themlophoc_tra.Enabled=false;
            pb_xoalophoc_tra.Enabled = false;
        }

        private void b_themlophoc_tra_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv_lophoc_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_lophoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_malop_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["MaLop"].Value.ToString();
                tb_tenlop_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["TenLop"].Value.ToString();
                tb_khoahoc_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["KhoaHoc"].Value.ToString();
                tb_hedaotao_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["HeDaoTao"].Value.ToString();
                tb_namnhaphoc_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["NamNhapHoc"].Value.ToString();
                cb_makhoa_tra.Text = dgv_lophoc_tra.Rows[dongchon].Cells["MaKhoa"].Value.ToString();
            }
        }
        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_lophoc_tra.DataSource = dt;
            //
            SqlCommand cmd1 = new SqlCommand("select * from khoa", frm_DangNhap_Tra.con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_makhoa_tra.DataSource = dt1;
            cb_makhoa_tra.DisplayMember = "MaKhoa";
            cb_makhoa_tra.ValueMember = "MaKhoa";
        }

        private void pb_timsinhvien_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc where TenLop like N'%" + tb_timlophoc_tra.Text + "' or MaLop like N'%" + tb_timlophoc_tra.Text + "%'", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_lophoc_tra.DataSource = dt;
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }

        private void pb_themlophoc_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
               "insert into lop_hoc(MaLop,TenLop,KhoaHoc,HeDaoTao,NamNhapHoc,MaKhoa)" +
               "values(@MaLop,@TenLop,@KhoaHoc,@HeDaoTao,@NamNhapHoc,@MaKhoa)", frm_DangNhap_Tra.con);
            cmd.Parameters.AddWithValue("@MaLop", tb_malop_tra.Text);
            cmd.Parameters.AddWithValue("@TenLop", tb_tenlop_tra.Text);
            cmd.Parameters.AddWithValue("@KhoaHoc", tb_khoahoc_tra.Text);
            cmd.Parameters.AddWithValue("@HeDaoTao", tb_hedaotao_tra.Text);
            cmd.Parameters.AddWithValue("@NamNhapHoc", tb_namnhaphoc_tra.Text);
            cmd.Parameters.AddWithValue("@MaKhoa", cb_makhoa_tra.Text);
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm lớp học thành công");
            else MessageBox.Show("Thêm lớp học thất bại");
            hienthidulieudatagridview();
        }

        private void pb_sualophoc_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_lophoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
               "Update lop_hoc set TenLop=@TenLop,KhoaHoc=@KhoaHoc,HeDaoTao=@HeDaoTao, " +
               "NamNhapHoc=@NamNhapHoc,MaKhoa=@MaKhoa where MaLop=@MaLopcu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenLop", tb_tenlop_tra.Text);
                cmd.Parameters.AddWithValue("@KhoaHoc", tb_khoahoc_tra.Text);
                cmd.Parameters.AddWithValue("@HeDaoTao", tb_hedaotao_tra.Text);
                cmd.Parameters.AddWithValue("@NamNhapHoc", tb_namnhaphoc_tra.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cb_makhoa_tra.Text);
                cmd.Parameters.AddWithValue("@MaLopcu", dgv_lophoc_tra.Rows[dongchon].Cells["MaLop"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_xoalophoc_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_lophoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand("delete from lop_hoc where MaLop=@MaLop", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaLop", dgv_lophoc_tra.Rows[dongchon].Cells["MaLop"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa lớp học thành công");
                else MessageBox.Show("Xóa lớp học thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_sapxeplop_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc order by TenLop asc ", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_lophoc_tra.DataSource = dt;
        }
    }
}
