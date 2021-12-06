using CuaHangPhanMem.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Command
{
    public enum TypeAction
    {
        Add,
        Update,
        Remove
    }

    public interface ICommandAction
    {
        void execute();
    }

    public class ActionRemoteControl
    {
        ICommandAction[] commands;
        public ActionRemoteControl() {
            commands = new ICommandAction[3];
        }

        public void SetCommandAction(int slot, ICommandAction command)
        {
            commands[slot] = command;
        }

        public void buttonWasPressed(int slot)
        {
            if(commands[slot] == null)
            {
                return;
            }
            commands[slot].execute();
        }
    }

   

    public class CustomerAddCommand : ICommandAction
    {
        private Form formCustomer;
        
        public CustomerAddCommand(Form form)
        {
            formCustomer = (frKhachHang)form;
        }

        public void execute()
        {
            IActionTemplate template = new AddCustomer();
            template.form = formCustomer;
            template.runAction();
        }
    }

    public class CustomerRemoveCommand : ICommandAction
    {
        private Form formCustomer;

        public CustomerRemoveCommand(Form form)
        {
            formCustomer = (frKhachHang)form;
        }
        public void execute()
        {
            IActionTemplate template = new RemoveCustomer();
            template.form = formCustomer;
            template.runAction();
        }
    }

    public class CustomerUpdateCommand : ICommandAction
    {
        private Form formCustomer;

        public CustomerUpdateCommand(Form form)
        {
            formCustomer = (frKhachHang)form;
        }
        public void execute()
        {
            IActionTemplate template = new UpdateCustomer();
            template.form = formCustomer;
            template.runAction();
        }
    }

    public class AccountAddCommand : ICommandAction
    {
        private Form formAccount;
        public AccountAddCommand(Form form)
        {
            formAccount = (frmAccount)form;
        }
        public void execute()
        {
            IActionTemplate template = new AddAccount();
            template.form = formAccount;
            template.runAction();
        }
    }

    public class AccountUpdateCommand : ICommandAction
    {
        private Form formAccount;
        public AccountUpdateCommand(Form form)
        {
            formAccount = (frmAccount)form;
        }
        public void execute()
        {
            IActionTemplate template = new UpdateAccount();
            template.form = formAccount;
            template.runAction();
        }
    }

    public class AccountRemoveCommand : ICommandAction
    {
        private Form formAccount;
        public AccountRemoveCommand(Form form)
        {
            formAccount = (frmAccount)form;
        }
        public void execute()
        {
            IActionTemplate template = new RemoveAccount();
            template.form = formAccount;
            template.runAction();
        }
    }

    public class ProductAddCommand : ICommandAction
    {
        private Form formProduct;
        public ProductAddCommand(Form form)
        {
            formProduct = (frmSanPham)form;
        }
        public void execute()
        {
            IActionTemplate template = new AddProduct();
            template.form = formProduct;
            template.runAction();
        }
    }

    public class ProductRemoveCommand : ICommandAction
    {
        private Form formProduct;
        public ProductRemoveCommand(Form form)
        {
            formProduct = (frmSanPham)form;
        }
        public void execute()
        {
            IActionTemplate template = new RemoveProduct();
            template.form = formProduct;
            template.runAction();
        }

    }

    public class ProductUpdateCommand : ICommandAction
    {
        private Form formProduct;
        public ProductUpdateCommand(Form form)
        {
            formProduct = (frmSanPham)form;
        }
        public void execute()
        {
            IActionTemplate template = new UpdateProduct();
            template.form = formProduct;
            template.runAction();
        }

    }

    public class ProductTypeAddCommand : ICommandAction
    {
        private Form formProductType;
        public ProductTypeAddCommand(Form form)
        {
            formProductType = (frmLoaiSP)form;
        }
        public void execute()
        {
            IActionTemplate template = new AddProductType();
            template.form = formProductType;
            template.runAction();
        }
    }

    public class ProductTypeUpdateCommand : ICommandAction
    {
        private Form formProductType;
        public ProductTypeUpdateCommand(Form form)
        {
            formProductType = (frmLoaiSP)form;
        }
        public void execute()
        {
            IActionTemplate template = new UpdateProductType();
            template.form = formProductType;
            template.runAction();
        }
    }

    public class ProductTypeRemoveCommand : ICommandAction
    {
        private Form formProductType;
        public ProductTypeRemoveCommand(Form form)
        {
            formProductType = (frmLoaiSP)form;
        }
        public void execute()
        {
            IActionTemplate template = new RemoveProductType();
            template.form = formProductType;
            template.runAction();
        }
    }
}
