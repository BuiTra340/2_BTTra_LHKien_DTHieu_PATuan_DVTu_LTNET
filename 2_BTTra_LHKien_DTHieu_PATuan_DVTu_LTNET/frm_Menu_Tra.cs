using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    public partial class frm_Menu_Tra : Form
    {
        public frm_Menu_Tra()
        {
            InitializeComponent();
        }

        private void nhậpĐiểmQuáTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Nhapdiemquatrinh_Tra f = new frm_Nhapdiemquatrinh_Tra();
            f.Show();
            this.Close();
        }

        private void nhậpĐiểmThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Nhapdiemthi_Tra f = new frm_Nhapdiemthi_Tra();
            f.Show();
            this.Close();
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Quanlydanhsachgiaovien_Tra f = new frm_Quanlydanhsachgiaovien_Tra();
            f.Show();
            this.Close();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Quanlykhoa_Tra f = new frm_Quanlykhoa_Tra();
            f.Show();
            this.Close();
        }

        private void điểmTrungBìnhChungTíchLũyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DiemTBChung_Tra f = new frm_DiemTBChung_Tra();
            f.Show();
            this.Close();
        }

        private void xuấtDanhSáchSinhViênnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhsachsinhvienExcel f = new frm_DanhsachsinhvienExcel();
            f.Show();
            this.Close();
        }

        private void xuấtDanhSáchĐiểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhsachdiemExcel_tra f = new frm_DanhsachdiemExcel_tra();
            f.Show();
            this.Close();
        }

        private void reportThôngTinBảngĐiểmCủa1SinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Thongtindiem1sinhvien f = new frm_Thongtindiem1sinhvien();
            f.Show();
            this.Close();
        }

        private void pb_quanlymonhoc_tra_Click(object sender, EventArgs e)
        {
            frm_Quanlymonhoc_Tra f = new frm_Quanlymonhoc_Tra();
            f.Show();
            this.Close();
        }

        private void pb_quanlyhososinhvien_tra_Click(object sender, EventArgs e)
        {
            frm_Quanlyhososinhvien_Tra f = new frm_Quanlyhososinhvien_Tra();
            f.Show();
            this.Close();
        }

        private void pb_quanlylophoc_tra_Click(object sender, EventArgs e)
        {
            frm_Quanlylophoc_Tra f = new frm_Quanlylophoc_Tra();
            f.Show();
            this.Close();
        }

        private void pb_quanlylophocphan_tra_Click(object sender, EventArgs e)
        {
            frm_Quanlylophocphan_Tra f = new frm_Quanlylophocphan_Tra();
            f.Show();
            this.Close();
        }
    }
}
