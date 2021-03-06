﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAppDemo.Controllers;
using WebAppDemo.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Text;
namespace WebAppDemo.Tests.Controllers {
    [TestClass]
    public class TeaTest {
        [TestMethod]
        public void TestIndex() {
            var db = new HenzaiEntities();
            var controller=new TeaController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<BubleTea>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count());

        }

        [TestMethod]
        public void TestDetails() {
            var db = new HenzaiEntities();
            var controller = new TeaController();
            var item = db.BubleTeas.First();
            var result = controller.Details(item.id) ;
            var view = result as ViewResult;

            Assert.IsNotNull(view);
            var model = view.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
            result = controller.Details(0);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));    

        }

        [TestMethod]
        public void TestCreateG() {
            var controller = new TeaController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);

            

        }

        [TestMethod]
        public void TestEditG() {
            var db = new HenzaiEntities();
            var controller = new TeaController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.AreEqual(item.id, model.id);

        }
     [TestMethod]
        public void TestCreateP() {
         var db=new HenzaiEntities();
         var model = new BubleTea
         
         {
             Name="Tra sua Matcha",
             Price= 28000,
             Topping="tran chau trang",
         };
         var controller = new TeaController();
         var result= controller.Create(model);
         var redirect = result as RedirectToRouteResult;
         Assert.IsNotNull(redirect);
         Assert.AreEqual("Index", redirect.RouteValues["action"]);
         var item = db.BubleTeas.Find(model.id);
         Assert.IsNotNull(item);
         Assert.AreEqual(model.Name, item.Name);
         Assert.AreEqual(model.Price, item.Price);
         Assert.AreEqual(model.Topping, item.Topping);
        }
        [TestMethod]
        public void TestEditP() {
            var db = new HenzaiEntities();
            var controller = new TeaController();
            var model = new BubleTea {
                Name = "Tra sua Matcha",
                Price = 28000,
                Topping = "tran chau trang",
            };
            var result = controller.Edit(model);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);



        }
    }
}
