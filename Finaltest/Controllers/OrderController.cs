using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finaltest.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(Models.Customer arg)
        {
            ///取得聯絡人職稱
            Models.CodeService codser = new Models.CodeService();
            Models.OrderService ser = new Models.OrderService();

            ViewBag.CustContactTitle = codser.GetCustContactTitle();
            if (arg.indexboo)
            {
                ///條件客戶資料
                ViewBag.custdata = ser.GetCustInforby(arg);
            }
            else
            {
                ///客戶資料
                ViewBag.custdata =ser.GetCustInfor();
            }
            return View();
        }

        public ActionResult InsertCustomer()
        {

            return View();
        }

        public ActionResult DeleteCustomer(int id)
        {

            return View();
        }



    }
}