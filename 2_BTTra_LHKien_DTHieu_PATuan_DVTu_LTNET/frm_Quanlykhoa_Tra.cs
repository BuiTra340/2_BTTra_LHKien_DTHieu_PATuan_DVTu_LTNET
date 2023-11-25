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
    public partial class frm_Quanlykhoa_Tra : Form
    {
        public frm_Quanlykhoa_Tra()
        {
            InitializeComponent();
        }

        private void frm_Quanlykhoa_Tra_Load(object sender, EventArgs e)
        {
            if (frm_DangNhap_Tra.loainguoidung.Equals("Sinh viên") ||
                frm_DangNhap_Tra.loainguoidung.Equals("Giáo viên")) DisableObject();
            hienthidulieudatagridview();
        }

        private void DisableObject()
        {
            tb_makhoa_tra.Enabled = false;
            tb_tenkhoa_tra.Enabled=false;
            pb_themkhoa_tra.Enabled = false;
            pb_suathongtinkhoa_tra.Enabled = false;
        }

        void hienthidulieudatagridview()
        {
            SqlCommand cmd = new SqlCommand("select * from khoa", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_danhsachkhoa_tra.DataSource = dt;
        }

        private void dgv_danhsachkhoa_tra_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgv_danhsachkhoa_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_makhoa_tra.Text = dgv_danhsachkhoa_tra.Rows[dongchon].Cells["MaKhoa"].Value.ToString();
                tb_tenkhoa_tra.Text = dgv_danhsachkhoa_tra.Rows[dongchon].Cells["TenKhoa"].Value.ToString();
            }
        }

        private void pb_themkhoa_tra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select * from khoa where MaKhoa ='" + tb_makhoa_tra.Text + "'", frm_DangNhap_Tra.con);
            if (cmd1.ExecuteScalar() == null)
            {
                SqlCommand cmd2 = new SqlCommand(
                "insert into khoa(MaKhoa,TenKhoa)" +
                "values(@MaKhoa,@TenKhoa)", frm_DangNhap_Tra.con);
                cmd2.Parameters.AddWithValue("@MaKhoa", tb_makhoa_tra.Text);
                cmd2.Parameters.AddWithValue("@TenKhoa", tb_tenkhoa_tra.Text);
                if (cmd2.ExecuteNonQuery() > 0) MessageBox.Show("Thêm khoa thành công");
                else MessageBox.Show("Thêm khoa thất bại");
            }
            else MessageBox.Show("Mã khoa tồn tại");
            hienthidulieudatagridview();
        }

        private void pb_suathongtinkhoa_tra_Click(object sender, EventArgs e)
        {
            int dongchon = dgv_danhsachkhoa_tra.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand(
               "Update khoa set TenKhoa=@TenKhoa where MaKhoa=@MaKhoacu", frm_DangNhap_Tra.con);
                cmd.Parameters.AddWithValue("@TenKhoa", tb_tenkhoa_tra.Text);
                cmd.Parameters.AddWithValue("@MaKhoacu", dgv_danhsachkhoa_tra.Rows[dongchon].Cells["MaKhoa"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa thành công");
                else MessageBox.Show("Sửa thất bại");
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
