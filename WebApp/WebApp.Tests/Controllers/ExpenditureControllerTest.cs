using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Models;
using WebApp.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using WebApp;


namespace WebApp.Tests.Controllers {
    [TestClass]
    public class ExpenditureControllerTest {
        [TestMethod]
        public void TestIndex() {
            var db = new QUANLYCHITIEUEntities();
            var controller = new ExpenditureController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<Expenditure>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.Expenditures.Count(),model.Count);
        }
        [TestMethod]
        public void TestCreateG() {
            var controller = new ExpenditureController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestEditG() {
            var controller = new ExpenditureController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new QUANLYCHITIEUEntities();
            var item = db.Expenditures.First();
            var result1 = controller.Edit(item.ID) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Expenditure;
            Assert.AreEqual(item.ID, model.ID);

        }
    }
}
