namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET
{
    partial class frm_DangNhap_DucAnh
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
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chb_htmk_dung = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_mk_dung = new System.Windows.Forms.TextBox();
            this.tb_Manv_dung = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(436, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "Đăng Nhập";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 227);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label4.Location = new System.Drawing.Point(667, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thoát";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // chb_htmk_dung
            // 
            this.chb_htmk_dung.AutoSize = true;
            this.chb_htmk_dung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chb_htmk_dung.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chb_htmk_dung.Location = new System.Drawing.Point(453, 270);
            this.chb_htmk_dung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chb_htmk_dung.Name = "chb_htmk_dung";
            this.chb_htmk_dung.Size = new System.Drawing.Size(157, 21);
            this.chb_htmk_dung.TabIndex = 26;
            this.chb_htmk_dung.Text = "Hiển thị mật khẩu";
            this.chb_htmk_dung.UseVisualStyleBackColor = true;
            this.chb_htmk_dung.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(451, 315);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 24;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_mk_dung
            // 
            this.tb_mk_dung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_mk_dung.Location = new System.Drawing.Point(453, 217);
            this.tb_mk_dung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_mk_dung.Multiline = true;
            this.tb_mk_dung.Name = "tb_mk_dung";
            this.tb_mk_dung.Size = new System.Drawing.Size(237, 30);
            this.tb_mk_dung.TabIndex = 23;
            this.tb_mk_dung.Text = "123";
            // 
            // tb_Manv_dung
            // 
            this.tb_Manv_dung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Manv_dung.Location = new System.Drawing.Point(453, 158);
            this.tb_Manv_dung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Manv_dung.Multiline = true;
            this.tb_Manv_dung.Name = "tb_Manv_dung";
            this.tb_Manv_dung.Size = new System.Drawing.Size(237, 30);
            this.tb_Manv_dung.TabIndex = 22;
            this.tb_Manv_dung.Text = "NV01";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::_02_NvCuong_DdAnh_HntAnh_BTLLTNET.Properties.Resources.Screenshot_2023_11_03_153743;
            this.pictureBox1.Location = new System.Drawing.Point(471, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(251, 390);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // frm_DangNhap_DucAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(761, 390);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chb_htmk_dung);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_mk_dung);
            this.Controls.Add(this.tb_Manv_dung);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_DangNhap_DucAnh";
            this.Text = "Đăng Nhập_Đức Anh";
            this.Load += new System.EventHandler(this.frm_DangNhap_Dung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chb_htmk_dung;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_mk_dung;
        private System.Windows.Forms.TextBox tb_Manv_dung;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

