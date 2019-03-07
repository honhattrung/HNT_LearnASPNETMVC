using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1 {
    [TestClass]
    public class CalculatorControllerTest {
        [TestMethod]
        public void TestIndex() { 
            // Arrange
         StudentController controller = new StudentController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestAuthor() {
            var controller = new StudentController();
            var result = controller.ShowAuthor();
            Assert.AreEqual("Hồ Nhật Trung", result);
        }
    }
}
