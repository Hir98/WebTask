using LoginReg.BL;
using LoginReg.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace LoginReg.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private webEntities db = new webEntities();
        BLogic bussinessobj = new BLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckValidUser(User detail)
        {
            string result = "Fail";
            var DataItem = db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefault();
            if (DataItem != null)
            {
                Session["Email"] = DataItem.Email.ToString();
                Session["Password"] = DataItem.Password.ToString();
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Welcome()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            DataSet ds = bussinessobj.Admin();
            ViewBag.User = ds.Tables[0];
            
            return View();
        }

        public ActionResult User()
        {
            return View();
        }
    }
}