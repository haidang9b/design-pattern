using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Template
{
    abstract class SellTemplate
    {
        public void Sell()
        {
            createBill();
            reduceProduct();
            printBill();
        }

        protected abstract void createBill();
        protected abstract void reduceProduct();
        protected abstract void printBill();
    }


}
