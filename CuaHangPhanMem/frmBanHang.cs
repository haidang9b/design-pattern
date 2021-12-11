using CuaHangPhanMem.DAO;
using CuaHangPhanMem.DTO;
using CuaHangPhanMem.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class frmBanHang : Form
    {
        public string nameStaff;
        public frmBanHang(string name)
        {
            InitializeComponent();
            nameStaff = name;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            loadCatagoryList();
            LoadKH();
            loadDataDonhang(0);

        }
        public void loadDataDonhang(int id)
        {
            var data = BillDAO.Instance.loadAllBillViewNonePay(id);
            dgvBillInfo.DataSource = data;
            int totalPrice = 0;
            foreach (ViewBillInfo item in data)
            {
                totalPrice += (int)item.TotalMoney;
            }
            txtTotal.Text = totalPrice.ToString();
        }
        ///load danh sach loai san pham
        private void loadCatagoryList()
        {
            List<ProductType> listCata = ProductTypeDAO.Instance.LoadAllProductType();
            comboBox1.DataSource = listCata;
            comboBox1.DisplayMember = "name";
        }

        //load loai san pham by id loai
        private void loadProductListByCatagoryID(int id)
        {
            List<Product> listProduct = ProductDAO.Instance.GetByProductTypeID(id);
            comboBox2.DataSource = listProduct;
            comboBox2.DisplayMember = "name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 1;
            ComboBox cb = sender as ComboBox;
            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            ProductType selected = comboBox1.SelectedItem as ProductType;
            id = selected.Id;
            loadProductListByCatagoryID(id);
        }
        // add kh neu chua co
        private void btnAddKH_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String sdt = txtSDT.Text;
            String dc = txtDC.Text;
           
            if (new ValidatorContext(name, ValidatorType.String).runValidation() && new ValidatorContext(sdt, ValidatorType.Phone).runValidation() && new ValidatorContext(dc, ValidatorType.String).runValidation())
            {
                try
                {
                    if (CustomerDAO.Instance.Add(new Customer(0, name, sdt, dc, 0, "")))
                    {
                        MessageBox.Show("Thêm khách hàng thành công !!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng mềm thất bại!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm khách hàng thất bại!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ");
            }
            LoadKH();
        }
        //load khach hang
        private void LoadKH()
        {
            dgvKhachHang.DataSource = CustomerDAO.Instance.GetCustomers();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtName.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtID.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDC.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSDT.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                loadDataDonhang(int.Parse(txtID.Text));

            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ");
            }
        }
        //clear cac textbox
        private void clearTextPhanMem()
        {
            comboBox1.SelectedIndex = 1;
            numericUpDown1.Value = 0;
            loadCatagoryList();

        }
        private void clearTextKH()
        {
            txtDC.Text = "";
            txtID.Text = "";
            txtTotal.Text = "";
            txtName.Text = "";
        }

        //add sl vao cthd
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation() ==  false)
            {
                MessageBox.Show("Vui lòng chọn khách hàng");
            }
            else if ((int)numericUpDown1.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn lại số lượng");
            }
            else
            {
                try
                {
                    int idKH = int.Parse(txtID.Text);
                    int idBill = BillDAO.Instance.GetUncheckBillByIDCustomer(idKH);
                    int idProduct = (comboBox2.SelectedItem as Product).ID;
                    int count = (int)numericUpDown1.Value;
                    int quantity = ProductDAO.Instance.GetCurrentQuantity(idProduct);

                    //create new bill
                    if (idBill == -1)
                    {
                        
                        if (count > quantity)
                        {
                            MessageBox.Show("Số lượng sản phẩm này chỉ còn " + quantity + " vui lòng chọn lại");
                            return;
                        }
                        BillDAO.Instance.Add(idKH, nameStaff);
                        //int idmax = BillDAO.Instance.getMaxID();
                        BillDAO.Instance.InsertBillInfo(BillDAO.Instance.getMaxID(), idProduct, count);
                    }
                    else
                    {
                        int quantityInBill = ProductDAO.Instance.GetQuantityInBillUnPayment(idBill, idProduct);
                        if(quantity < quantityInBill + count)
                        {
                            MessageBox.Show("Số lượng sản phẩm này chỉ còn " + quantity + " vui lòng chọn lại");
                            return;
                        }
                        BillDAO.Instance.InsertBillInfo(idBill, idProduct, count);
                    }
                    loadDataDonhang(idKH);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn hợp lệ");
                }
            }
        }
        //tim kiem kh co san
        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            try
            {
                int sdt = int.Parse(txtSDT.Text);
                dgvKhachHang.DataSource = CustomerDAO.Instance.SearchCustomerByPhone(sdt);
            }
            catch
            {
                MessageBox.Show("tìm không ra");
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

            try
            {
                int idkh = int.Parse(txtID.Text);
                if (idkh != 0)
                {
                    if (int.Parse(txtTotal.Text) != 0)
                    {
                        Thread th = new Thread(() =>
                        {
                            bool rs = BillDAO.Instance.PaytheBill(idkh);
                            if (rs)
                            {
                                MessageBox.Show("Thanh toán thành công. Khách hàng " + txtName.Text + " với đơn hàng trị giá " + txtTotal.Text + "VND. Hóa đơn sẽ hiện ngay sau đây");
                                int last_bill = BillDAO.Instance.getMaxID();
                                Form reportBill = new frmReportBill(last_bill, txtName.Text, txtTotal.Text);
                                reportBill.Show();
                                LoadKH();
                                loadDataDonhang(idkh);
                            }
                            else
                            {
                                MessageBox.Show("Thanh toán thất bại");
                            }
                        });
                        th.Start();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn đơn hàng của khách hàng đang mua");
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng của khách hàng cần thanh toán");
                }

            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại");
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
        //giam gia don hang
        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(txtTotal.Text);
                int dis = (int)nudDiscount.Value;
                float moneyDis = money * dis / 100;
                txtTotal.Text = (money - moneyDis).ToString();
            }
            catch
            {
                MessageBox.Show("Giảm giá thất bại");
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
