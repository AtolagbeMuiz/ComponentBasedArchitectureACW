using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.VirtualMachine
{
    public interface IVirtualMachine
    {
        //Properties
        Stack Stack { get; set; }
        int ProgramCounter { get; set; }

        //Methods
        void Run();
    }
}
