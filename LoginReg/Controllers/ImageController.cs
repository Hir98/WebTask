using LoginReg.Models;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginReg.Controllers
{
    public class ImageController : Controller
    {
        //public SqlCommand cmd = null;
        private String str;
        private string msg = string.Empty;
        private SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        // GET: Image
        private webEntities db = new webEntities();
        public ActionResult Index()
        {
            return View("AddImage");
        }


        public ActionResult ImageUpload(User model)
        {
          
            int imgId = 0;
            var file = model.postedFile;
            byte[] imagebyte = null;
        


            conn.Open();
            // str = "select count(*) FROM [Users] Where FirstName='" + details.FirstName + "' ";
           // int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (file != null)
            {
                SqlCommand cmd = null;

                file.SaveAs(Server.MapPath("/UploadImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);

                cmd = new SqlCommand("insert into Users (Avatar) VALUES (@Avatar)", conn);
               //    cmd.Parameters.AddWithValue("@FirstName", details.FirstName);
                // cmd = new SqlCommand(str, conn);
                //cmd.Parameters.AddWithValue("UserId", Id);
                User user = new User();
                // user.ImageTitle = file.FileName;
                user.Avatar = imagebyte;
                cmd.Parameters.AddWithValue("@Avatar", user.Avatar);
                cmd.ExecuteNonQuery();

               
               // user.ImagePath = "/UploadImage/" + file.FileName;
               // db.Users.Add(user);
              //  db.SaveChanges();
                //imgId = img.ImageId;
            }
            return Json(imgId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayingImage(int imgid)
        {
           
            var img = db.Users.SingleOrDefault(x => x.UserId == imgid);
            return File(img.Avatar, "image/jpg");
        }

        /*
              public ActionResult AddImage()
              {
                  User user = new User();
                  return View();
              }
              [HttpPost]
              public ActionResult AddImage(User model, HttpPostedFileBase postedFile)
              {
                  if (postedFile != null)
                  {
                      model.Avatar = new byte[postedFile.ContentLength];
                      postedFile.InputStream.Read(model.Avatar, 0, postedFile.ContentLength);
                  }
                  const string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                  // string Type = fileData + mimeType + fileName;
                  using (var conn = new SqlConnection(connect))
                  {
                      var qry = "INSERT INTO Users (Avatar) VALUES(@Avatar)";
                      var cmd = new SqlCommand(qry, conn);
                      // cmd.Parameters.AddWithValue("@Type", Type);
                      cmd.Parameters.AddWithValue("@Avatar", model.Avatar);
                      conn.Open();
                      cmd.ExecuteNonQuery();

                  }
                //  db.Users.Add(model);
                //  db.SaveChanges();
                  return View();
              }
              //check whether the FileUpload control contain file or not
              /*      public bool HasFile(HttpPostedFileBase file)
                    {

                        return (file != null && file.ContentLength > 0) ? true : false;
                    }

                  //upload images in database one by one one if FileUpload contain file

                   public ActionResult Index()
                   {
                       foreach (string upload in Request.Files)
                       {
                           if (!HasFile(Request.Files[upload])) continue;
                           string mimeType = Request.Files[upload].ContentType;
                           Stream fileStream = Request.Files[upload].InputStream;
                           string fileName = Path.GetFileName(Request.Files[upload].FileName);
                           int fileLength = Request.Files[upload].ContentLength;
                           byte[] fileData = new byte[fileLength];
                           fileStream.Read(fileData, 0, fileLength);
                           // const string connect = @"Server=your_servername;Database=your_database 
                           //;User Id=user_id;password=password;";
                           const string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                         // string Type = fileData + mimeType + fileName;
                           using (var conn = new SqlConnection(connect))
                           {
                               var qry = "INSERT INTO Users (FileContent, MimeType, FileName) VALUES(@FileContent, @MimeType, @FileName)";
                               var cmd = new SqlCommand(qry, conn);
                             // cmd.Parameters.AddWithValue("@Type", Type);
                              cmd.Parameters.AddWithValue("@FileContent", fileData);
                              cmd.Parameters.AddWithValue("@MimeType", mimeType);
                              cmd.Parameters.AddWithValue("@FileName", fileName);
                               conn.Open();
                               cmd.ExecuteNonQuery();

                           }

                       }

                       return View();

                   }*/

        //get the file id and return a file to the browser
        /*  public FileContentResult GetFile(int id)
          {
              SqlDataReader rdr;
              byte[] fileContent = null;
              string mimeType = "";
              string fileName = "";
              const string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";


              using (var conn = new SqlConnection(connect))
              {
                  var qry = "SELECT FileContent, MimeType, FileName FROM Users WHERE UserId= @UserId";
                  var cmd = new SqlCommand(qry, conn);
                  cmd.Parameters.AddWithValue("@UserId", UserId);
                  conn.Open();
                  rdr = cmd.ExecuteReader();
                  if (rdr.HasRows)
                  {
                      rdr.Read();
                      fileContent = (byte[])rdr["FileContent"];
                      mimeType = rdr["MimeType"].ToString();
                      fileName = rdr["FileName"].ToString();

                  }

              }

              return File(fileContent, mimeType, fileName);

          }*/
    }
}