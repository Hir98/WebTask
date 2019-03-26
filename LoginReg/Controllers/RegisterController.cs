//using LoginReg.BusinessLogic;
//using LoginReg.Controllers.Business;
//using LoginReg.Controllers.Data;
using LoginReg.BL;
using LoginReg.Models;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Web.Mvc;



namespace LoginReg.Controllers
{
    public class RegisterController : Controller
    {
       // private static IBLLReg _objIBLLReg;

        private webEntities db = new webEntities();

        //public RegisterController()
        //{
        //    _objIBLLReg = new BLLReg(new DALReg());
        //}

        public ActionResult Index()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddUser(User details)
        {
            //string result = _objIBLLReg.addRecord(details);
            //return Json(result, JsonRequestBehavior.AllowGet);
            BLogic obj = new BLogic();
            string result = obj.addRecord(details);
            return Json(result, JsonRequestBehavior.AllowGet);
           
        }
       

    }
}