namespace _2_BTTra_LHKien_DTHieu_PATuan_DVTu_LTNET
{
    partial class frm_Thongtindiem1sinhvien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Thongtindiem1sinhvien));
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_masinhvien_tra = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_hienthireport_tra = new System.Windows.Forms.PictureBox();
            this.pb_quaylai_tra = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_hienthireport_tra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quaylai_tra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN ĐIỂM CỦA 1 SINH VIÊN";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportViewer1.Location = new System.Drawing.Point(0, 274);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1344, 415);
            this.reportViewer1.TabIndex = 2;
            // 
            // tb_masinhvien_tra
            // 
            this.tb_masinhvien_tra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_masinhvien_tra.Location = new System.Drawing.Point(634, 199);
            this.tb_masinhvien_tra.Name = "tb_masinhvien_tra";
            this.tb_masinhvien_tra.Size = new System.Drawing.Size(190, 30);
            this.tb_masinhvien_tra.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(330, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(727, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(477, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mã sinh viên";
            // 
            // pb_hienthireport_tra
            // 
            this.pb_hienthireport_tra.Image = ((System.Drawing.Image)(resources.GetObject("pb_hienthireport_tra.Image")));
            this.pb_hienthireport_tra.Location = new System.Drawing.Point(908, 180);
            this.pb_hienthireport_tra.Name = "pb_hienthireport_tra";
            this.pb_hienthireport_tra.Size = new System.Drawing.Size(130, 60);
            this.pb_hienthireport_tra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_hienthireport_tra.TabIndex = 48;
            this.pb_hienthireport_tra.TabStop = false;
            this.pb_hienthireport_tra.Click += new System.EventHandler(this.pb_hienthireport_tra_Click);
            // 
            // pb_quaylai_tra
            // 
            this.pb_quaylai_tra.Image = ((System.Drawing.Image)(resources.GetObject("pb_quaylai_tra.Image")));
            this.pb_quaylai_tra.Location = new System.Drawing.Point(1124, 189);
            this.pb_quaylai_tra.Name = "pb_quaylai_tra";
            this.pb_quaylai_tra.Size = new System.Drawing.Size(84, 57);
            this.pb_quaylai_tra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_quaylai_tra.TabIndex = 49;
            this.pb_quaylai_tra.TabStop = false;
            this.pb_quaylai_tra.Click += new System.EventHandler(this.pb_quaylai_tra_Click);
            // 
            // frm_Thongtindiem1sinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1344, 689);
            this.Controls.Add(this.pb_quaylai_tra);
            this.Controls.Add(this.pb_hienthireport_tra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_masinhvien_tra);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frm_Thongtindiem1sinhvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Thongtindiem1sinhvien";
            this.Load += new System.EventHandler(this.frm_Thongtindiem1sinhvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_hienthireport_tra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quaylai_tra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox tb_masinhvien_tra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb_hienthireport_tra;
        private System.Windows.Forms.PictureBox pb_quaylai_tra;
    }
}