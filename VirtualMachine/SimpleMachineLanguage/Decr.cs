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

            //checks if the value is of type integer
            if(topValueOnStack.GetType() == typeof(int))
            {
                Console.WriteLine("The initial value loaded on the stack is " + topValueOnStack);

                //converts the top value to type integer 
                var convertedValueToInteger = Convert.ToInt32(topValueOnStack);

                //decrement the top value on the stack
                convertedValueToInteger--;

                //push the new value into the stack
                VirtualMachine.Stack.Push(convertedValueToInteger);

                Console.WriteLine("The decremented value pushed on the stack is " + convertedValueToInteger);

            }
            else
            {
                throw new SvmRuntimeException("The top value of the stack is not an integer");
            }
        }
		catch (SvmRuntimeException ex)
		{
			throw new SvmRuntimeException(ex.Message);
		}
    }
        #endregion
}
