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
    public partial class frm_Quanlylophocphan_Tra : Form
    {
        public frm_Quanlylophocphan_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quanlylophocphan_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
               frm_DangNhap_Tra.loainguoidung.Equals("Giáo viên")) DisableObject();
            hienthidulieudatagridview();
        }

        private void DisableObject()
        {
            cb_magiaovien_tra.Enabled = false;
            cb_malophoc_tra.Enabled = false;
            cb_mamonhoc_tra.Enabled = false;
            tb_hocky_tra.Enabled = false;
            tb_nam_tra.Enabled=false;
            pb_sualophocphan_tra.Enabled=false;
            pb_themlophocphan_tra.Enabled=false;
            pb_xoalophocphan_tra.Enabled = false;
        }

        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc_phan", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_lophocphan_tra.DataSource = dt;
            //
            SqlCommand cmd1 = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_malophoc_tra.DataSource = dt1;
            cb_malophoc_tra.DisplayMember = "MaLop";
            cb_malophoc_tra.ValueMember = "MaLop";
            //
            SqlCommand cmd2 = new SqlCommand("select * from mon_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cb_mamonhoc_tra.DataSource = dt2;
            cb_mamonhoc_tra.DisplayMember = "MaMonHoc";
            cb_mamonhoc_tra.ValueMember = "MaMonHoc";
            //
            SqlCommand cmd3 = new SqlCommand("select * from giao_vien", frm_DangNhap_Tra.con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cb_magiaovien_tra.DataSource = dt3;
            cb_magiaovien_tra.DisplayMember = "MaGiaoVien";
            cb_magiaovien_tra.ValueMember = "MaGiaoVien";
        }

        private void dgv_lophocphan_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_lophocphan_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                cb_malophoc_tra.Text = dgv_lophocphan_tra.Rows[dongchon].Cells["MaLop"].Value.ToString();
                cb_mamonhoc_tra.Text = dgv_lophocphan_tra.Rows[dongchon].Cells["MaMonHoc"].Value.ToString();
                cb_magiaovien_tra.Text = dgv_lophocphan_tra.Rows[dongchon].Cells["MaGiaoVien"].Value.ToString();
                tb_hocky_tra.Text = dgv_lophocphan_tra.Rows[dongchon].Cells["HocKy"].Value.ToString();
                tb_nam_tra.Text = dgv_lophocphan_tra.Rows[dongchon].Cells["Nam"].Value.ToString();
            }
        }
        private void pb_themlophocphan_tra_Click(object sender, EventArgs e)
        {
            int hocky = int.Parse(tb_hocky_tra.Text);
            if (hocky >= 1 && hocky <= 8)
            {
                SqlCommand cmd = new SqlCommand(
                "insert into lop_hoc_phan(MaLop,MaMonHoc,MaGiaoVien,HocKy,Nam)" +
                "values(@MaLop,@MaMonHoc,@MaGiaoVien,@HocKy,@Nam)", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaLop", cb_malophoc_tra.Text);
                cmd.Parameters.AddWithValue("@MaMonHoc", cb_mamonhoc_tra.Text);
                cmd.Parameters.AddWithValue("@MaGiaoVien", cb_magiaovien_tra.Text);
                cmd.Parameters.AddWithValue("@HocKy", tb_hocky_tra.Text);
                cmd.Parameters.AddWithValue("@Nam", tb_nam_tra.Text);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm lớp học phần thành công");
                else MessageBox.Show("Thêm lớp học phần thất bại");
            }
            else
                MessageBox.Show("Học kỳ phải là 1 số nguyên từ 1 đến 8");

            hienthidulieudatagridview();
        }

        private void pb_sualophocphan_tra_Click(object sender, EventArgs e)
        {
            int hocky = int.Parse(tb_hocky_tra.Text);
            if (hocky >= 1 && hocky <= 8)
            {
                int dongchon = dgv_lophocphan_tra.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    SqlCommand cmd = new SqlCommand(
                   "Update lop_hoc_phan set MaGiaoVien=@MaGiaoVien,HocKy=@HocKy, Nam=@Nam where MaLop=@MaLopcu and MaMonHoc=@MaMonHoccu", frm_DangNhap_Tra.con);
                    cmd.Parameters.AddWithValue("@MaGiaoVien", cb_magiaovien_tra.Text);
                    cmd.Parameters.AddWithValue("@HocKy", tb_hocky_tra.Text);
                    cmd.Parameters.AddWithValue("@Nam", tb_nam_tra.Text);
                    cmd.Parameters.AddWithValue("@MaLopcu", dgv_lophocphan_tra.Rows[dongchon].Cells["MaLop"].Value.ToString());
                    cmd.Parameters.AddWithValue("@MaMonHoccu", dgv_lophocphan_tra.Rows[dongchon].Cells["MaMonHoc"].Value.ToString());
                    if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                    else MessageBox.Show("Sửa thất bại");
                    hienthidulieudatagridview();
                }
            }
            else MessageBox.Show("Học kỳ phải là 1 số nguyên từ 1 đến 8");
        }

        private void pb_xoalophocphan_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_lophocphan_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand("delete from lop_hoc_phan where MaLop=@MaLop", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaLop", dgv_lophocphan_tra.Rows[dongchon].Cells["MaLop"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa lớp học phần thành công");
                else MessageBox.Show("Xóa lớp học phần thất bại");
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
