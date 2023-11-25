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
    public partial class frm_Quanlymonhoc_Tra : Form
    {
        public frm_Quanlymonhoc_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quanlymonhoc_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
               frm_DangNhap_Tra.loainguoidung.Equals("Giáo viên")) DisableObject();
            hienthidulieudatagridview();
        }

        private void DisableObject()
        {
            tb_mamonhoc_tra.Enabled = false;
            tb_tenmonhoc_tra.Enabled=false;
            tb_sotinchi_tra.Enabled=false;
            pb_sapxepmonhoc_tra.Enabled = false;
            pb_suamonhoc_tra.Enabled=false;
            pb_themmonhoc_tra.Enabled = false;
            pb_xoamonhoc_tra.Enabled = false;
        }

        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from mon_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_monhoc_tra.DataSource = dt;
        }

        private void dgv_monhoc_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_monhoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_mamonhoc_tra.Text = dgv_monhoc_tra.Rows[dongchon].Cells["MaMonHoc"].Value.ToString();
                tb_tenmonhoc_tra.Text = dgv_monhoc_tra.Rows[dongchon].Cells["TenMonHoc"].Value.ToString();
                tb_sotinchi_tra.Text = dgv_monhoc_tra.Rows[dongchon].Cells["SoTinChi"].Value.ToString();
            }
        }

        private void pb_timmonhoc_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from mon_hoc where TenMonHoc like N'%" + tb_timmonhoc_tra.Text + "' or MaMonHoc like N'%" + tb_timmonhoc_tra.Text + "%'", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_monhoc_tra.DataSource = dt;
        }

        private void pb_themmonhoc_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "insert into mon_hoc(MaMonHoc,TenMonHoc,SoTinChi)" +
                "values(@MaMonHoc,@TenMonHoc,@SoTinChi)", frm_DangNhap_Tra.con);
            cmd.Parameters.AddWithValue("@MaMonHoc", tb_mamonhoc_tra.Text);
            cmd.Parameters.AddWithValue("@TenMonHoc", tb_tenmonhoc_tra.Text);
            cmd.Parameters.AddWithValue("@SoTinChi", tb_sotinchi_tra.Text);
            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm môn học thành công");
            else MessageBox.Show("Thêm môn học thất bại");
            hienthidulieudatagridview();
        }

        private void pb_suamonhoc_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_monhoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
               "Update mon_hoc set TenMonHoc=@TenMonHoc,SoTinChi=@SoTinChi where MaMonHoc=@MaMonHoccu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenMonHoc", tb_tenmonhoc_tra.Text);
                cmd.Parameters.AddWithValue("@SoTinChi", tb_sotinchi_tra.Text);
                cmd.Parameters.AddWithValue("@MaMonHoccu", dgv_monhoc_tra.Rows[dongchon].Cells["MaMonHoc"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_xoamonhoc_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_monhoc_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand("delete from mon_hoc where MaMonHoc=@MaMonHoc", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@MaMonHoc", dgv_monhoc_tra.Rows[dongchon].Cells["MaMonHoc"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa môn học thành công");
                else MessageBox.Show("Xóa môn học thất bại");
                hienthidulieudatagridview();
            }
        }

        private void pb_sapxepmonhoc_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from mon_hoc order by SoTinChi asc ", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_monhoc_tra.DataSource = dt;
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
