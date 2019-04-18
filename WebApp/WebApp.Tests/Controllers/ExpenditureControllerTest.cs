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
    }
}
