using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Queue
{
    public class CommandInvoker
    {
        private ICommand command;

        public void SetCommand(ICommand command) => this.command = command;

        public void ExecuteCommand()
        {
            if (command != null)
            {
                command.Execute();
            }
            else
            {
                throw new InvalidOperationException("command not define");
            }
        }
    }
}
