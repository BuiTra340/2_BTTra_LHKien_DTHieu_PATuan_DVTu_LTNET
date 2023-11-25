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
    public partial class frm_DangNhap_Tra : Form
    {
        public static string loainguoidung = string.Empty;
        public static SqlConnection con;
        public frm_DangNhap_Tra()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Tra_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source =.\SQLEXPRESS;Initial Catalog = Quanlysinhvien; Integrated Security = True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void frm_DangNhap_Tra_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from nguoi_dung where (TenDangNhap=N'" + tb_tendangnhap_tra.Text + @"'and  MatKhau=N'" + tb_matkhau_tra.Text + @"')", con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read())
            {
                loainguoidung = dt["LoaiNguoiDung"].ToString();
                this.Hide();
                if (loainguoidung.Equals("Admin"))
                {
                    dt.Close();
                    frm_Quantrivien_Tra f = new frm_Quantrivien_Tra();
                    f.Show();

                }
                else
                {
                    dt.Close();
                    frm_Menu_Tra f = new frm_Menu_Tra();
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
                dt.Close();
            }
        }
    }
}
