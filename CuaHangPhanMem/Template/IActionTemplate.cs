using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Template
{
    public abstract class IActionTemplate
    {
        public Form form { get; set; }
        public void runAction()
        {
            action();
            if (hasDone())
            {
                ClearTextBox();
                LoadData();
            }
        }

        protected abstract void action(); 
        protected abstract void ClearTextBox();
        protected abstract void LoadData();
        
        protected virtual bool hasDone()
        {
            return true;
        }

    }
}
