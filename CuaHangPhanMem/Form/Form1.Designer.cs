namespace CuaHangPhanMem
{
    partial class BanHangStaff
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
            System.Windows.Forms.Label lbTitleCurrent;
            this.btnInfoApp = new FontAwesome.Sharp.IconButton();
            this.panelKhachhang = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.iconCurrentTitle = new FontAwesome.Sharp.IconPictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBanHang = new System.Windows.Forms.Panel();
            this.btnTKDH = new System.Windows.Forms.Button();
            this.btnTaoDH = new System.Windows.Forms.Button();
            this.labelBar = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtNamelogin = new System.Windows.Forms.Label();
            this.txtNameUser = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            lbTitleCurrent = new System.Windows.Forms.Label();
            this.panelKhachhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentTitle)).BeginInit();
            this.panelBanHang.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitleCurrent
            // 
            lbTitleCurrent.AutoSize = true;
            lbTitleCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbTitleCurrent.ForeColor = System.Drawing.Color.White;
            lbTitleCurrent.Location = new System.Drawing.Point(82, 13);
            lbTitleCurrent.Name = "lbTitleCurrent";
            lbTitleCurrent.Size = new System.Drawing.Size(0, 20);
            lbTitleCurrent.TabIndex = 1;
            // 
            // btnInfoApp
            // 
            this.btnInfoApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnInfoApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfoApp.FlatAppearance.BorderSize = 0;
            this.btnInfoApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoApp.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnInfoApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoApp.ForeColor = System.Drawing.Color.White;
            this.btnInfoApp.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.btnInfoApp.IconColor = System.Drawing.Color.White;
            this.btnInfoApp.IconSize = 36;
            this.btnInfoApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoApp.Location = new System.Drawing.Point(0, 474);
            this.btnInfoApp.Name = "btnInfoApp";
            this.btnInfoApp.Rotation = 0D;
            this.btnInfoApp.Size = new System.Drawing.Size(220, 60);
            this.btnInfoApp.TabIndex = 24;
            this.btnInfoApp.Text = "Giới thiệu";
            this.btnInfoApp.UseVisualStyleBackColor = false;
            this.btnInfoApp.Click += new System.EventHandler(this.btnInfoApp_Click);
            // 
            // panelKhachhang
            // 
            this.panelKhachhang.BackColor = System.Drawing.Color.DarkBlue;
            this.panelKhachhang.Controls.Add(this.button2);
            this.panelKhachhang.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKhachhang.Location = new System.Drawing.Point(0, 414);
            this.panelKhachhang.Name = "panelKhachhang";
            this.panelKhachhang.Size = new System.Drawing.Size(220, 60);
            this.panelKhachhang.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 50);
            this.button2.TabIndex = 0;
            this.button2.Text = "Quản lý khách hàng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnKhachHang.IconColor = System.Drawing.Color.White;
            this.btnKhachHang.IconSize = 36;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 354);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Rotation = 0D;
            this.btnKhachHang.Size = new System.Drawing.Size(220, 60);
            this.btnKhachHang.TabIndex = 17;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
            this.btnHome.IconColor = System.Drawing.Color.White;
            this.btnHome.IconSize = 36;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 116);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Rotation = 0D;
            this.btnHome.Size = new System.Drawing.Size(220, 60);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Trang chủ";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // iconCurrentTitle
            // 
            this.iconCurrentTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(96)))), ((int)(((byte)(201)))));
            this.iconCurrentTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iconCurrentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(96)))), ((int)(((byte)(201)))));
            this.iconCurrentTitle.IconChar = FontAwesome.Sharp.IconChar.BoxTissue;
            this.iconCurrentTitle.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(96)))), ((int)(((byte)(201)))));
            this.iconCurrentTitle.IconSize = 30;
            this.iconCurrentTitle.Location = new System.Drawing.Point(46, 9);
            this.iconCurrentTitle.Name = "iconCurrentTitle";
            this.iconCurrentTitle.Size = new System.Drawing.Size(30, 37);
            this.iconCurrentTitle.TabIndex = 0;
            this.iconCurrentTitle.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 53);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1044, 903);
            this.panelContent.TabIndex = 7;
            // 
            // panelBanHang
            // 
            this.panelBanHang.BackColor = System.Drawing.Color.DarkBlue;
            this.panelBanHang.Controls.Add(this.btnTKDH);
            this.panelBanHang.Controls.Add(this.btnTaoDH);
            this.panelBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanHang.Location = new System.Drawing.Point(0, 236);
            this.panelBanHang.Name = "panelBanHang";
            this.panelBanHang.Size = new System.Drawing.Size(220, 118);
            this.panelBanHang.TabIndex = 8;
            // 
            // btnTKDH
            // 
            this.btnTKDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTKDH.FlatAppearance.BorderSize = 0;
            this.btnTKDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTKDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKDH.Location = new System.Drawing.Point(0, 50);
            this.btnTKDH.Name = "btnTKDH";
            this.btnTKDH.Size = new System.Drawing.Size(220, 50);
            this.btnTKDH.TabIndex = 2;
            this.btnTKDH.Text = "Tìm kiếm đơn hàng";
            this.btnTKDH.UseVisualStyleBackColor = true;
            this.btnTKDH.Click += new System.EventHandler(this.btnTKDH_Click);
            // 
            // btnTaoDH
            // 
            this.btnTaoDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaoDH.FlatAppearance.BorderSize = 0;
            this.btnTaoDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDH.Location = new System.Drawing.Point(0, 0);
            this.btnTaoDH.Name = "btnTaoDH";
            this.btnTaoDH.Size = new System.Drawing.Size(220, 50);
            this.btnTaoDH.TabIndex = 0;
            this.btnTaoDH.Text = "Tạo đơn hàng";
            this.btnTaoDH.UseVisualStyleBackColor = true;
            this.btnTaoDH.Click += new System.EventHandler(this.btnTaoDH_Click);
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBar.ForeColor = System.Drawing.Color.White;
            this.labelBar.Location = new System.Drawing.Point(99, 13);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(80, 20);
            this.labelBar.TabIndex = 2;
            this.labelBar.Text = "Trang chủ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(96)))), ((int)(((byte)(201)))));
            this.panel2.Controls.Add(this.labelBar);
            this.panel2.Controls.Add(lbTitleCurrent);
            this.panel2.Controls.Add(this.iconCurrentTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(220, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 53);
            this.panel2.TabIndex = 6;
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnBanHang.IconColor = System.Drawing.Color.White;
            this.btnBanHang.IconSize = 36;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Location = new System.Drawing.Point(0, 176);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Rotation = 0D;
            this.btnBanHang.Size = new System.Drawing.Size(220, 60);
            this.btnBanHang.TabIndex = 7;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin chào";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.txtNamelogin);
            this.panel1.Controls.Add(this.txtNameUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 116);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogout.Location = new System.Drawing.Point(59, 90);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Thoát";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtNamelogin
            // 
            this.txtNamelogin.AutoSize = true;
            this.txtNamelogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamelogin.Location = new System.Drawing.Point(68, 32);
            this.txtNamelogin.Name = "txtNamelogin";
            this.txtNamelogin.Size = new System.Drawing.Size(66, 24);
            this.txtNamelogin.TabIndex = 2;
            this.txtNamelogin.Text = "label2";
            // 
            // txtNameUser
            // 
            this.txtNameUser.AutoSize = true;
            this.txtNameUser.Location = new System.Drawing.Point(69, 40);
            this.txtNameUser.Name = "txtNameUser";
            this.txtNameUser.Size = new System.Drawing.Size(10, 13);
            this.txtNameUser.TabIndex = 1;
            this.txtNameUser.Text = " ";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.panelMenu.Controls.Add(this.btnInfoApp);
            this.panelMenu.Controls.Add(this.panelKhachhang);
            this.panelMenu.Controls.Add(this.btnKhachHang);
            this.panelMenu.Controls.Add(this.panelBanHang);
            this.panelMenu.Controls.Add(this.btnBanHang);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 956);
            this.panelMenu.TabIndex = 5;
            // 
            // BanHangStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 956);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "BanHangStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán phần mềm : Staff";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelKhachhang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentTitle)).EndInit();
            this.panelBanHang.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnInfoApp;
        private System.Windows.Forms.Panel panelKhachhang;
        private System.Windows.Forms.Button button2;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconPictureBox iconCurrentTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBanHang;
        private System.Windows.Forms.Button btnTKDH;
        private System.Windows.Forms.Button btnTaoDH;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnBanHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtNamelogin;
        private System.Windows.Forms.Label txtNameUser;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLogout;
    }
}