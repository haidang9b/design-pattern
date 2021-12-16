using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Adapter
{
    public interface AdapterDataGridView
    {
        void AddRow(DataRow item);
        void RemoveRow(int index);
        void UpdateRow(DataRow item, int index);
        void LoadData();
    }

    public class CustomerApdater : AdapterDataGridView
    {
        private DataGridView dgv;

        public CustomerApdater(DataGridView dataGridView)
        {
            this.dgv = dataGridView;
        }

        public void AddRow(DataRow item)
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            /*dgv = CustomerDAO*/
        }

        public void RemoveRow(int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateRow(DataRow item, int index)
        {
            throw new NotImplementedException();
        }
    }
}
