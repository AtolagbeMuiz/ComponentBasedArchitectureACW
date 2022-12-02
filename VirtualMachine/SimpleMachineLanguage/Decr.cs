namespace SVM.SimpleMachineLanguage;

/// <summary>
/// Implements the SML Decr  instruction
/// Decrements the integer value stored on top of the stack, 
/// leaving the result on the stack
/// </summary>
public class Decr : BaseInstruction
{
    #region TASK 3 - TO BE IMPLEMENTED BY THE STUDENT
    public override void Run()
    {
		try
		{
            //checks if the stack has atleast a value
            if (VirtualMachine.Stack.Count < 1)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }
            //pops the top value of the stack
            var topValueOnStack = VirtualMachine.Stack.Pop();

            //checks is the value is of type interger
            if(topValueOnStack.GetType() == typeof(int))
            {
                //converts the top value to type integer 
                var convertedValueToInteger = Convert.ToInt32(topValueOnStack);

                //decrement the top value on the stack
                convertedValueToInteger--;

                //push the new value into the stack
                VirtualMachine.Stack.Push(convertedValueToInteger);
            }
            else
            {
                throw new SvmRuntimeException("The top value of the stack is not an inerger");
            }
        }
		catch (SvmRuntimeException ex)
		{
			throw new SvmRuntimeException(ex.Message);
		}
    }
        #endregion
}
