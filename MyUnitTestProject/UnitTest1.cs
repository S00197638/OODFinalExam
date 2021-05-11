using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JakeBeecham_S00197638;

namespace MyUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDecreasePrice()
        {
            //Arrange
            Game g1 = new Game("Overwatch", 91, "PC", 30m);
            decimal finalPrice = 15m;

            //Act
            g1.DecreasePrice(15m);

            //Assert
            Assert.AreEqual(finalPrice, g1.Price);
        }
    }
}
