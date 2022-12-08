using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SVM.SimpleMachineLanguage;
using SVM.VirtualMachine;

namespace SVMUnitTest
{
    [TestClass]
    public class IncrUnitTest
    {
        [TestMethod]
        public void Run_PopTheTopStackValue_IncrementIt_PushTheIncrementedValueOntoTheStack()
        {
            //--> Testing the Run Method in the Incr Class
            //--> The Run Method does not return any value and
            //--> The Incr class does not Implement IVirtualMachine Interface
            //--> The best way to test this unit is to verify that the Run method is called Once

            //Arange
            var incrMock = new Mock<Incr>();

            //Act
            incrMock.Object.Run();

            //Assert
            incrMock.Verify(x => x.Run(), Times.Once)
;
        }
    }
}
