using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Command
{
    public class RemoteCommandControl
    {
        public ICommandControl[] commands;
        public RemoteCommandControl(params ICommandControl[] buttons)
        {
            this.commands = buttons;
        }
        public void run()
        {
            foreach(var c in commands)
            {
                c.execute();
            }
        }
    }

    public abstract class ICommandControl
    {
        protected Control button;
        public ICommandControl(Control button)
        {
            this.button = button;
        }

        public abstract void execute();

    }

    public class EnableCommand : ICommandControl
    {
        public EnableCommand(Control button) : base(button) { }
        public override void execute()
        {
            button.Enabled = true;
         
        }
    }

    public class DisableCommand : ICommandControl
    {
        public DisableCommand(Control button) : base(button) { }
        public override void execute()
        {
            button.Enabled = false;
        }
    }
}
