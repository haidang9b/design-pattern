using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Command
{
    public abstract class ICommandButton
    {
        protected Button[] buttons;
        public ICommandButton(Button[] buttons)
        {
            this.buttons = buttons;
        }

        public abstract void execute();

    }

    public class EnableCommand : ICommandButton
    {
        public EnableCommand(params Button[] buttons) : base(buttons) { }
        public override void execute()
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = true;
            }
        }
    }

    public class DisableCommand : ICommandButton
    {
        public DisableCommand(params Button[] buttons) : base(buttons) { }
        public override void execute()
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = false;
            }
        }
    }
}
