using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class ArrayListController : Controller
    {
        static object[] Buffer = new object[10];
        static int Length = 0;
        public ActionResult Index()
        {
            var model= new Tuple<object[], int>(Buffer, Length);

            return View(model);
        }
        public ActionResult Append(string value) {
            Buffer[Length] = value;
            Length++;
            return RedirectToAction("Index");
        }
        public ActionResult Clear() {
            Length = 0;
            return RedirectToAction("Index");
        }
        public ActionResult Insert(int key, string value) {
            for (int i = Length-1; i>= key; i--) {
                Buffer[i + 1] = Buffer[i];
                Buffer[key] = value;
                Length++;
            }
            
            return RedirectToAction("Index");
        }

	}
}