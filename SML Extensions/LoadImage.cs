using SVM.VirtualMachine;
using System;
using System.Drawing;

namespace SML_Extensions
{
    internal class LoadImage : BaseInstructionWithOperand
    {

       
        public override void Run()
        {
            try
            {
                if (Operands[0].GetType() != typeof(string))
                {
                    throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                    this.ToString(), VirtualMachine.ProgramCounter));
                }
                if (Operands[0] != null)
                {
                    //converts the image file path to image
                    Image newImage = Image.FromFile(Operands[0]);

                    VirtualMachine.Stack.Push(newImage);

                }


            }
            catch (SvmRuntimeException ex)
            {
                
                throw new SvmRuntimeException("");
            }
        }
    }
}
