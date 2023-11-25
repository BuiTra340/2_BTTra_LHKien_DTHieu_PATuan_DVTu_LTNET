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
    public partial class frm_DiemTBChung_Tra : Form
    {
        public frm_DiemTBChung_Tra()
        {
            InitializeComponent();
        }

        private void frm_DiemTBChung_Tra_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from lop_hoc", frm_DangNhap_Tra.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_lop_tra.DataSource = dt;
            cb_lop_tra.DisplayMember = "TenLop";
            cb_lop_tra.ValueMember = "MaLop";
            
        }

        void DSSV()
        {
            List<string> listMaSv = new List<string>(); 
            List<string> listHoTen = new List<string>();
            List<string> listTenLop = new List<string>();
            SqlCommand cmd = new SqlCommand("select distinct MaSinhVien,HoDem,Ten,lop_hoc.TenLop from sinh_vien join lop_hoc_phan on " +
                "lop_hoc_phan.MaLop = sinh_vien.MaLop " +
                "join lop_hoc on sinh_vien.MaLop = lop_hoc.MaLop " +
                "where lop_hoc_phan.HocKy = '"+cb_hocky_tra.Text+"' and lop_hoc_phan.Nam='"+tb_namhoc_tra.Text+"' " +
                "and sinh_vien.MaLop='"+cb_lop_tra.SelectedValue.ToString() + "'", frm_DangNhap_Tra.con);
            SqlDataReader dt = cmd.ExecuteReader();
            int indexTen = 0;
            while (dt.Read())
            {
                listMaSv.Add(dt["MaSinhVien"].ToString());
                listHoTen.Add(dt["HoDem"].ToString());
                listHoTen[indexTen] += "" + dt["Ten"].ToString();
                listTenLop.Add(dt["TenLop"].ToString());
                indexTen++;
            }
            dt.Close();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã sinh viên");
            dataTable.Columns.Add("Họ Tên");
            dataTable.Columns.Add("Lớp");
            dataTable.Columns.Add("Điểm trung bình chung HK");
            for (int i = 0; i < listMaSv.Count; i++)
            {
                cmd = new SqlCommand("select diem.MaSinhVien,diem.MaMonHoc,DiemHocPhan,lop_hoc_phan.HocKy," +
                    "lop_hoc_phan.Nam,mon_hoc.SoTinChi from diem join lop_hoc_phan " +
                    "on lop_hoc_phan.MaMonHoc = diem.MaMonHoc join mon_hoc on mon_hoc.MaMonHoc = lop_hoc_phan.MaMonHoc " +
                    " where lop_hoc_phan.MaLop='" + cb_lop_tra.SelectedValue.ToString() + "' and diem.MaSinhVien='" + listMaSv[i].ToString() + "'", frm_DangNhap_Tra.con);
                dt = cmd.ExecuteReader();
                int tongTinChi = 0;
                float diemTBChungHK = 0;
                while (dt.Read())
                {
                    int soTinChi = int.Parse(dt["SoTinChi"].ToString());
                    float diemHocPhan = float.Parse(dt["DiemHocPhan"].ToString());
                    tongTinChi += soTinChi;
                    diemTBChungHK += soTinChi * diemHocPhan;
                }
                diemTBChungHK /= tongTinChi;
                diemTBChungHK = (float)Math.Round(diemTBChungHK, 2);
                dt.Close();
                //
                if (diemTBChungHK >= 7)
                {
                    DataRow row = dataTable.NewRow();
                    row["Điểm trung bình chung HK"] = diemTBChungHK.ToString();
                    row["Mã sinh viên"] = listMaSv[i].ToString();
                    row["Họ Tên"] = listHoTen[i].ToString();
                    row["Lớp"] = listTenLop[i].ToString();
                    dataTable.Rows.Add(row);
                }
            }
            dataTable = sapXepDiemGiamDan(dataTable, "Điểm trung bình chung HK");
            dataTable = SvDatHocBong(dataTable);
            dgv_hienthidiem_tra.DataSource = dataTable;
        }
        private DataTable sapXepDiemGiamDan(DataTable dataTable,string sortRow)
        {
            if(dataTable.Rows.Count != 0)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = sortRow;
                dataTable = dataView.ToTable();
                var sortedRows = dataTable.AsEnumerable()
                    .OrderByDescending(row => row.Field<string>(sortRow))
                    .CopyToDataTable();
                dataTable = sortedRows;
            }
            return dataTable;
        }
        DataTable SvDatHocBong(DataTable dataTable)
        {
            int removeIndex = (int)(dataTable.Rows.Count * 0.1f);
            //dataTable bat dau tu 0 nen phai -1
            for(int i = dataTable.Rows.Count - 1; i> removeIndex;i--)
            {
                dataTable.Rows[i].Delete();
            }
            dataTable.AcceptChanges();
            return dataTable;
        }

        private void b_hienthi_tra_Click(object sender, EventArgs e)
        {
            
        }

        private void b_quaylai_tra_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_hienthi_tra_Click(object sender, EventArgs e)
        {
            DSSV();
        }

        private void pb_quaylai_tra_Click(object sender, EventArgs e)
        {
            frm_Menu_Tra f = new frm_Menu_Tra();
            f.Show();
            this.Close();
        }
    }
}
