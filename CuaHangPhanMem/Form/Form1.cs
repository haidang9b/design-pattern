using CuaHangPhanMem.Command;
using CuaHangPhanMem.DAO;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class BanHangStaff : Form
    {
        private IconButton currentBtn;
        private Panel leftPanel;
        private Form childFormCurrent;
        public string nameStaff;
        public BanHangStaff()
        {
            InitializeComponent();
            leftPanel = new Panel();
            leftPanel.Size = new Size(8, 60);
            panelMenu.Controls.Add(leftPanel);
            customDesign();
            txtNamelogin.Text = SaveDataStatic.login.FullName == null ? "" : SaveDataStatic.login.FullName;
            nameStaff = SaveDataStatic.login.FullName == null ? "" : SaveDataStatic.login.FullName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new fromHome());
            labelBar.Text = "Hệ thống quản lý bán phần mềm";
        }
        private struct RGBColor
        {
            public static Color colorActive1 = Color.FromArgb(172, 126, 241);
            public static Color colorActive2 = Color.FromArgb(249, 118, 176);
            public static Color colorActive3 = Color.FromArgb(253, 138, 114);
            public static Color colorActive4 = Color.FromArgb(82, 255, 59);
            public static Color colorActive5 = Color.FromArgb(24, 161, 251);
            public static Color colorActive6 = Color.FromArgb(183, 183, 183);
            public static Color colorActive7 = Color.FromArgb(115, 6, 200);
            public static Color colorActive8 = Color.FromArgb(200, 6, 138);

        }
        private void customDesign()
        {
            panelBanHang.Visible = false;
            panelKhachhang.Visible = false;

        }
        private void hideSubMenu()
        {
            if (panelBanHang.Visible == true)
                panelBanHang.Visible = false;
            if (panelKhachhang.Visible == true)
                panelKhachhang.Visible = false;
        }
        private void showSubMenu(Panel sub)
        {
            if (sub.Visible == false)
            {
                hideSubMenu();
                sub.Visible = true;
            }
            else
                sub.Visible = false;
        }
        private void ActiveBtn(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableBtn();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(7, 62, 145);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftPanel.BackColor = color;
                leftPanel.Location = new Point(0, currentBtn.Location.Y);
                leftPanel.Visible = true;
                leftPanel.BringToFront();
                iconCurrentTitle.IconChar = currentBtn.IconChar;
                iconCurrentTitle.ForeColor = color;

            }
        }
        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(54, 125, 232);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (childFormCurrent != null)
            {
                childFormCurrent.Close();
            }
            childFormCurrent = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, RGBColor.colorActive2);
            childFormCurrent.Close();
            showSubMenu(panelBanHang);
            labelBar.Text = "Bán hàng";
        }

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang(nameStaff));
            labelBar.Text = "Bán hàng > Tạo đơn hàng";
        }

        private void btnTKDH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTimKiemDonHang());
            labelBar.Text = "Bán hàng > Tìm kiếm đơn hàng";
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, RGBColor.colorActive4);
            childFormCurrent.Close();
            labelBar.Text = "Khách hàng";
            showSubMenu(panelKhachhang);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frKhachHang());
            labelBar.Text = "Khách hàng > Khách hàng thân thiết";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelBar.Text = "Khách hàng > Tìm kiếm khách hàng";
        }

        private void btnInfoApp_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, RGBColor.colorActive7);
            labelBar.Text = "Giới thiệu";
            OpenChildForm(new frmInfoApp());
            hideSubMenu();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginCommand command = new LoginForm();
            command.Logout();
            this.Hide();
        }
    }
}
