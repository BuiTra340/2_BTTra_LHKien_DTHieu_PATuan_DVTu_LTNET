namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    partial class frm_Nhapdiemthi_Tra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Nhapdiemthi_Tra));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_hienthidanhsachsinhvien_tra = new System.Windows.Forms.DataGridView();
            this.cb_chonmonhoc_tra = new System.Windows.Forms.ComboBox();
            this.cb_chonlophoc_tra = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_diemthi_tra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pb_nhapdiemthi_tra = new System.Windows.Forms.PictureBox();
            this.pb_quaylai_tra = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hienthidanhsachsinhvien_tra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nhapdiemthi_tra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quaylai_tra)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(429, 670);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Môn học";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 670);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "Lớp";
            // 
            // dgv_hienthidanhsachsinhvien_tra
            // 
            this.dgv_hienthidanhsachsinhvien_tra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_hienthidanhsachsinhvien_tra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hienthidanhsachsinhvien_tra.Location = new System.Drawing.Point(12, 196);
            this.dgv_hienthidanhsachsinhvien_tra.Name = "dgv_hienthidanhsachsinhvien_tra";
            this.dgv_hienthidanhsachsinhvien_tra.RowHeadersWidth = 51;
            this.dgv_hienthidanhsachsinhvien_tra.RowTemplate.Height = 24;
            this.dgv_hienthidanhsachsinhvien_tra.Size = new System.Drawing.Size(1235, 449);
            this.dgv_hienthidanhsachsinhvien_tra.TabIndex = 38;
            this.dgv_hienthidanhsachsinhvien_tra.SelectionChanged += new System.EventHandler(this.dgv_hienthidanhsachsinhvien_tra_SelectionChanged);
            // 
            // cb_chonmonhoc_tra
            // 
            this.cb_chonmonhoc_tra.FormattingEnabled = true;
            this.cb_chonmonhoc_tra.Location = new System.Drawing.Point(573, 674);
            this.cb_chonmonhoc_tra.Name = "cb_chonmonhoc_tra";
            this.cb_chonmonhoc_tra.Size = new System.Drawing.Size(150, 24);
            this.cb_chonmonhoc_tra.TabIndex = 36;
            this.cb_chonmonhoc_tra.SelectedIndexChanged += new System.EventHandler(this.cb_chonmonhoc_tra_SelectedIndexChanged);
            // 
            // cb_chonlophoc_tra
            // 
            this.cb_chonlophoc_tra.FormattingEnabled = true;
            this.cb_chonlophoc_tra.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_chonlophoc_tra.Location = new System.Drawing.Point(163, 671);
            this.cb_chonlophoc_tra.Name = "cb_chonlophoc_tra";
            this.cb_chonlophoc_tra.Size = new System.Drawing.Size(150, 24);
            this.cb_chonlophoc_tra.TabIndex = 37;
            this.cb_chonlophoc_tra.SelectedIndexChanged += new System.EventHandler(this.cb_chonlophoc_tra_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(834, 670);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 40;
            this.label1.Text = "Điểm thi";
            // 
            // tb_diemthi_tra
            // 
            this.tb_diemthi_tra.Location = new System.Drawing.Point(984, 670);
            this.tb_diemthi_tra.Name = "tb_diemthi_tra";
            this.tb_diemthi_tra.Size = new System.Drawing.Size(152, 22);
            this.tb_diemthi_tra.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(503, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 38);
            this.label7.TabIndex = 44;
            this.label7.Text = "NHẬP ĐIỂM THI";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1259, 824);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(434, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(457, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // pb_nhapdiemthi_tra
            // 
            this.pb_nhapdiemthi_tra.Image = ((System.Drawing.Image)(resources.GetObject("pb_nhapdiemthi_tra.Image")));
            this.pb_nhapdiemthi_tra.Location = new System.Drawing.Point(881, 728);
            this.pb_nhapdiemthi_tra.Name = "pb_nhapdiemthi_tra";
            this.pb_nhapdiemthi_tra.Size = new System.Drawing.Size(130, 60);
            this.pb_nhapdiemthi_tra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_nhapdiemthi_tra.TabIndex = 47;
            this.pb_nhapdiemthi_tra.TabStop = false;
            this.pb_nhapdiemthi_tra.Click += new System.EventHandler(this.pb_nhapdiemthi_tra_Click);
            // 
            // pb_quaylai_tra
            // 
            this.pb_quaylai_tra.Image = ((System.Drawing.Image)(resources.GetObject("pb_quaylai_tra.Image")));
            this.pb_quaylai_tra.Location = new System.Drawing.Point(1083, 731);
            this.pb_quaylai_tra.Name = "pb_quaylai_tra";
            this.pb_quaylai_tra.Size = new System.Drawing.Size(84, 57);
            this.pb_quaylai_tra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_quaylai_tra.TabIndex = 48;
            this.pb_quaylai_tra.TabStop = false;
            this.pb_quaylai_tra.Click += new System.EventHandler(this.pb_quaylai_tra_Click);
            // 
            // frm_Nhapdiemthi_Tra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1259, 824);
            this.Controls.Add(this.pb_quaylai_tra);
            this.Controls.Add(this.pb_nhapdiemthi_tra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_diemthi_tra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_hienthidanhsachsinhvien_tra);
            this.Controls.Add(this.cb_chonmonhoc_tra);
            this.Controls.Add(this.cb_chonlophoc_tra);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frm_Nhapdiemthi_Tra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Nhapdiemthi_Tra";
            this.Load += new System.EventHandler(this.frm_Nhapdiemthi_Tra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hienthidanhsachsinhvien_tra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nhapdiemthi_tra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quaylai_tra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_hienthidanhsachsinhvien_tra;
        private System.Windows.Forms.ComboBox cb_chonmonhoc_tra;
        private System.Windows.Forms.ComboBox cb_chonlophoc_tra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_diemthi_tra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pb_nhapdiemthi_tra;
        private System.Windows.Forms.PictureBox pb_quaylai_tra;
    }
}