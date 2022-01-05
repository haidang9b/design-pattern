
namespace CuaHangPhanMem
{
    partial class frmNotifyEmail
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGui = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDinhKem = new System.Windows.Forms.TextBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.openFileDialogEmail = new System.Windows.Forms.OpenFileDialog();
            this.English = new System.Windows.Forms.CheckBox();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.btnUndo = new FontAwesome.Sharp.IconButton();
            this.btnRedo = new FontAwesome.Sharp.IconButton();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(165, 111);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(628, 29);
            this.txtTitle.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(165, 185);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(628, 407);
            this.txtContent.TabIndex = 1;
            this.txtContent.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiêu đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nội dung";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label6);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1351, 72);
            this.panel9.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(186, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(552, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "GỬI EMAIL TOÀN CHO TẤT CẢ KHÁCH HÀNG";
            // 
            // btnGui
            // 
            this.btnGui.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnGui.IconChar = FontAwesome.Sharp.IconChar.Line;
            this.btnGui.IconColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGui.IconSize = 30;
            this.btnGui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGui.Location = new System.Drawing.Point(834, 185);
            this.btnGui.Name = "btnGui";
            this.btnGui.Rotation = 0D;
            this.btnGui.Size = new System.Drawing.Size(140, 59);
            this.btnGui.TabIndex = 21;
            this.btnGui.Text = "Gửi ";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnClear
            // 
            this.btnClear.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.btnClear.IconColor = System.Drawing.Color.SandyBrown;
            this.btnClear.IconSize = 30;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(834, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Rotation = 0D;
            this.btnClear.Size = new System.Drawing.Size(140, 59);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Nhập lại";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 623);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Đính kèm";
            // 
            // txtDinhKem
            // 
            this.txtDinhKem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDinhKem.Location = new System.Drawing.Point(165, 623);
            this.txtDinhKem.Name = "txtDinhKem";
            this.txtDinhKem.ReadOnly = true;
            this.txtDinhKem.Size = new System.Drawing.Size(522, 29);
            this.txtDinhKem.TabIndex = 39;
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(693, 623);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(100, 29);
            this.btnAttach.TabIndex = 40;
            this.btnAttach.Text = "Tệp";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // openFileDialogEmail
            // 
            this.openFileDialogEmail.FileName = "openFileDialog1";
            this.openFileDialogEmail.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            // 
            // English
            // 
            this.English.AutoSize = true;
            this.English.Location = new System.Drawing.Point(834, 142);
            this.English.Margin = new System.Windows.Forms.Padding(2);
            this.English.Name = "English";
            this.English.Size = new System.Drawing.Size(117, 17);
            this.English.TabIndex = 42;
            this.English.Text = "Gửi kèm Tiếng Anh";
            this.English.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSave.IconSize = 30;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(834, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Rotation = 0D;
            this.btnSave.Size = new System.Drawing.Size(140, 59);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUndo.IconChar = FontAwesome.Sharp.IconChar.Undo;
            this.btnUndo.IconColor = System.Drawing.Color.SandyBrown;
            this.btnUndo.IconSize = 30;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(834, 419);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Rotation = 0D;
            this.btnUndo.Size = new System.Drawing.Size(140, 59);
            this.btnUndo.TabIndex = 44;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRedo.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnRedo.IconColor = System.Drawing.Color.SandyBrown;
            this.btnRedo.IconSize = 30;
            this.btnRedo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedo.Location = new System.Drawing.Point(834, 497);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Rotation = 0D;
            this.btnRedo.Size = new System.Drawing.Size(140, 59);
            this.btnRedo.TabIndex = 45;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // frmNotifyEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 706);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.English);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.txtDinhKem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTitle);
            this.Name = "frmNotifyEmail";
            this.Text = "FormNotifyEmail";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnGui;
        private FontAwesome.Sharp.IconButton btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDinhKem;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.OpenFileDialog openFileDialogEmail;
        private System.Windows.Forms.CheckBox English;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnUndo;
        private FontAwesome.Sharp.IconButton btnRedo;
    }
}