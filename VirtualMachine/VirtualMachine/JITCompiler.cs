﻿namespace SVM.VirtualMachine;

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


            //getting the defined C# types
            var assemblyInheritingIInstruction = Assembly.GetExecutingAssembly().DefinedTypes.ToList();

            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*dll");
            foreach (var file in files)
            {
                var v = AppDomain.CurrentDomain;
                Assembly asm = Assembly.LoadFile(file);


                if (asm != null)
                {
                    foreach (TypeInfo type in asm.DefinedTypes)
                    {
                        assemblyInheritingIInstruction.Add(type);
                    }
                }

            }

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
            //--> Get all the loaded C# types in the executing assembly
            //--> Get the all the DLL files that are .NET
            //--> Loop through these files, and add it to the list of C# Types of the executing assembly
            //--> find the type that implement IInstruction interface

            var assemblyInheritingIInstruction = Assembly.GetExecutingAssembly().DefinedTypes.ToList();

            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*dll");
            foreach (var file in files)
            {
                var v = AppDomain.CurrentDomain;
                Assembly asm = Assembly.LoadFile(file);

                
                if(asm != null)
                {
                    foreach (TypeInfo type in asm.DefinedTypes)
                    {
                        assemblyInheritingIInstruction.Add(type);
                    }
                }

            }

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
