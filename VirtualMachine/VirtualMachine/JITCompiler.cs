namespace SVM.VirtualMachine;

using SVM.SimpleMachineLanguage;

#region Using directives
using System.Reflection;
#endregion

/// <summary>
/// Utility class which generates compiles a textual representation
/// of an SML instruction into an executable instruction instance
/// </summary>
internal static class JITCompiler
{
    #region Constants
    #endregion

    #region Fields
    #endregion

    #region Constructors
    #endregion

    #region Properties
    #endregion

    #region Public methods
    #endregion

    #region Non-public methods
    internal static IInstruction CompileInstruction(string opcode)
    {
        IInstruction instruction = null;

        #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT
        //Implement the logic to convert a textual SML instruction to an executable equivalent
        try
        {
            //--> declare the targetted Interface
            //--> Get all the loaded assemblies in this domain
            //--> Get the types of these assemblies
            //--> find the type that implement IInstruction interface
            
            //var interfacetarget = typeof(IInstruction);

            //searches for the assembly that implement IInstruction using reflection and returns the first one found
            //var assemblyInheritingIInstruction = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(x => interfacetarget.IsAssignableFrom(x) && x.Name == opcode).FirstOrDefault();

            //Type assemblyInheritingIInstruction = Type.GetType("SVM.SimpleMachineLanguage.WriteString");

            //var assemblyInheritingIInstruction = (from asm in AppDomain.CurrentDomain.GetAssemblies()
            //                                         from type in asm.GetTypes()
            //                                         where type.IsClass && type.Name == opcode
            //                                         select type).Single();

            var assemblyInheritingIInstruction = Assembly.GetExecutingAssembly().DefinedTypes;
            //.Where(x => x.Name == opcode).FirstOrDefault();

            //checking the returned assembly if it contains data
            if (assemblyInheritingIInstruction == null)
            {
                throw new SvmCompilationException("An Invalid SML instruction has been found in the source file");
            }
            else
            {
                foreach (var assemblyType in assemblyInheritingIInstruction)
                {
                    //comapares the sml opcode with the Type and also checks if the Type implement IInstruction interface
                    if ((string.Equals(assemblyType.Name, opcode, StringComparison.OrdinalIgnoreCase)) && assemblyType.GetInterfaces().Contains(typeof(IInstruction)))
                    {
                        //creates an instance of the type and explicitly casts the retuned type to IInstruction type

                        instruction = (IInstruction)Activator.CreateInstance(assemblyType);

                        //terminates the loop;
                        //this break statement improves performance of a logic to prevent the loop from further running when the condition has been met
                        break;

                    }
                }
            }
        }
        catch (SvmCompilationException svmEx)
        {
            Console.WriteLine("An Invalid SML instruction has been found in the source file: Error Message " + svmEx.Message);
            throw;
        }
        #endregion
        return instruction;
    }

    internal static IInstruction CompileInstruction(string opcode, params string[] operands)
    {
        IInstructionWithOperand instruction = null;

        #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT

        try
        {
            //--> declare the targetted Interface
            //--> Get all the loaded assemblies in this domain
            //--> Get the types of these assemblies
            //--> find the type that implement IInstruction interface

            var assemblyInheritingIInstruction = Assembly.GetExecutingAssembly().DefinedTypes;

            //checking the returned assembly if it contains data
            if (assemblyInheritingIInstruction == null)
            {
                throw new SvmCompilationException("An Invalid SML instruction has been found in the source file");
            }
            else
            {
                foreach (var assemblyType in assemblyInheritingIInstruction)
                {
                    //comapares the sml opcode with the Type and also checks if the Type implement IInstruction interface
                    if ((string.Equals(assemblyType.Name, opcode, StringComparison.OrdinalIgnoreCase)) && assemblyType.GetInterfaces().Contains(typeof(IInstruction)))
                    {
                        //creates an instance of the type and explicitly casts the retuned type to IInstruction type

                        instruction = (IInstructionWithOperand)Activator.CreateInstance(assemblyType);                      
                        instruction.Operands = operands;

                        //terminates the loop;
                        //this break statement improves performance of a logic to prevent the loop from further running when the condition has been met
                        break;

                    }
                }
            }
        }
        catch (SvmCompilationException svmEx)
        {
            Console.WriteLine("An Invalid SML instruction has been found in the source file: Error Message " + svmEx.Message);
            throw;
        }
        #endregion
        return instruction;
    }
    #endregion
}
