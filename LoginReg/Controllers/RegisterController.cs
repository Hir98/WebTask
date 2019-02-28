using LoginReg.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace LoginReg.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private String str;

        private SqlCommand cmd = null;
        private webEntities db = new webEntities();
        private SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser(User model)
        {
            /*conn.Open();
            str = "select count(*) FROM [Users] Where FirstName='" + model.FirstName + "' ";
            SqlCommand cmd = new SqlCommand(str, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();*/

            string msg = string.Empty;
            try
            {
                conn.Open();
                str = "select count(*) FROM [Users] Where FirstName='" + model.FirstName + "' ";
                SqlCommand cmd = new SqlCommand(str, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                

                if (count > 0)
                {
                    msg = "Sorry! you can't take this username";
                }
                else
                {
                    // int len = Upload.PostedFile.ContentLength;
                    // byte[] pic = new byte[len + 1];
                    //  Upload.PostedFile.InputStream.Read(pic, 0, len);

                    cmd = new SqlCommand("insert into Users  (FirstName,LastName,Email,Mobile,Password,CreatedDate,LastLoginDate,Status) VALUES (@FirstName,@LastName,@Email,@Mobile,@Password,@CreatedDate,@LastLoginDate,@Status)", conn);

                    //cmd.Parameters.AddWithValue("UserId", Id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Mobile", model.Mobile);
                    cmd.Parameters.AddWithValue("@Password", model.Password);

                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@LastLoginDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Status", "Active");
                    //  cmd.Parameters.AddWithValue("@Avatar", "Active");
                   //  cmd.Parameters.AddWithValue("@Avatar", (pic != null && pic.Length > 0) ? pic : null);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg = "User Details Inserted Successfully!";
                    
                    //    Response.Redirect("Login.aspx");
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                msg = "Error!!!";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

         
        }

       
    }
}