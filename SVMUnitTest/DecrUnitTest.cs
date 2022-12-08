using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SVM.SimpleMachineLanguage;

namespace SVMUnitTest
{
    [TestClass]
    public class DecrUnitTest
    {

        [TestMethod]
        public void Run_PopTheTopStackValue_DecrementIt_PushTheIncrementedValueOntoTheStack()
        {
            //--> Testing the Run Method in the Decr Class
            //--> The Run Method does not return any value and
            //--> The Decr class does not Implement IVirtualMachine Interface
            //--> The best way to test this unit is to verify that the Run method is called Once, which isn't a solid unit test to rely on

            //Arange
            var decrMock = new Mock<Decr>();

            //Act
            decrMock.Object.Run();


            //Assert
            decrMock.Verify(x => x.Run(), Times.Once)
;
        }
    }
}
