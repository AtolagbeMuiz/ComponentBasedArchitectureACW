using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Debugger
{
    internal class DisplayImage : BaseInstruction
    {
        public override void Run()
        {
            try
            {
                PaintEventArgs e = null;

                //checks if the stack has atleast a value
                if (VirtualMachine.Stack.Count < 1)
                {
                    throw new SvmRuntimeException("The stack contains no Image");
                }

                var topImageOnStack = VirtualMachine.Stack.Pop();

                if((topImageOnStack != null) && (topImageOnStack.GetType() == typeof(Image)))
                {
                    Image img = (Image)topImageOnStack;

                    e.Graphics.DrawImage(img, 20.0F, 20.0F);
                }
                else
                {
                    throw new SvmRuntimeException("Ivalid Image or Image file cannot be found");
                }
            }
            catch (SvmRuntimeException ex)
            {

                throw new SvmRuntimeException("Runtime Exception while drawing Image");
            }
            
        }
    }
}
