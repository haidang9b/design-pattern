using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Command
{
    public abstract class ICommandControl
    {
        protected Control[] buttons;
        public ICommandControl(params Control[] buttons)
        {
            this.buttons = buttons;
        }

        public abstract void execute();

    }

    public class EnableCommand : ICommandControl
    {
        public EnableCommand(params Control[] buttons) : base(buttons) { }
        public override void execute()
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = true;
            }
        }
    }

    public class DisableCommand : ICommandControl
    {
        public DisableCommand(params Control[] buttons) : base(buttons) { }
        public override void execute()
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = false;
            }
        }
    }
}
