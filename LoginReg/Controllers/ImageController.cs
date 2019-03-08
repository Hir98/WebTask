using LoginReg.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginReg.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        private webEntities db = new webEntities();
        public ActionResult Index()
        {
            return View();
        }


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

             }
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