using LoginReg.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace LoginReg.BL
{
    public class BLogic
    {
        private String str;
        private string msg = string.Empty;
        private SqlCommand cmd = null;

        private SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=web;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        public string addRecord(User details)
        {
            try
            {
                int imgId = 0;
                var file = details.postedFile;
                byte[] imagebyte = null;
                conn.Open();
                str = "select count(*) FROM [Users] Where FirstName='" + details.FirstName + "' ";
                SqlCommand cmd = new SqlCommand(str, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    msg = "Duplicate";
                    return msg;
                }
                else
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Current.Server.MapPath("/UploadImage/" + file.FileName));
                        BinaryReader reader = new BinaryReader(file.InputStream);
                        imagebyte = reader.ReadBytes(file.ContentLength);
                        details.Avatar = imagebyte;
                    }

                    /*if (postedFile != null)
                    {
                        details.Avatar = new byte[postedFile.ContentLength];
                        postedFile.InputStream.Read(details.Avatar, 0, postedFile.ContentLength);
                    }*/
                    cmd = new SqlCommand("insert into Users  (FirstName,LastName,Email,Mobile,Password,CreatedDate,Avatar,Status,Type) VALUES (@FirstName,@LastName,@Email,@Mobile,@Password,@CreatedDate,@Avatar,@Status,@Type)", conn);
                    // cmd = new SqlCommand("insert into Users  (FirstName,LastName,Email,Mobile,Password,CreatedDate,Status,Type) VALUES (@FirstName,@LastName,@Email,@Mobile,@Password,@CreatedDate,@Status,@Type)", conn);

                    cmd.Parameters.AddWithValue("@FirstName", details.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", details.LastName);
                    cmd.Parameters.AddWithValue("@Email", details.Email);
                    cmd.Parameters.AddWithValue("@Mobile", details.Mobile);
                    cmd.Parameters.AddWithValue("@Password", details.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Status", "Active");
                    cmd.Parameters.AddWithValue("@Avatar", details.Avatar);
                    cmd.Parameters.AddWithValue("@Type", "Admin");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg = "User Details Inserted Successfully!";
                }
                return msg;
            }
            catch (Exception e)
            {
                msg = "Error!!!";
                return msg;
            }
        }

        public string LoginUser(User detail)
        {
            try
            {
                conn.Open();
                str = "select count(*) FROM [Users] Where email='" + detail.Email + "' and Password='" + detail.Password + "' ";
                SqlCommand cmd = new SqlCommand(str, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    cmd = new SqlCommand("update [Users] set LastLoginDate=@LastLoginDate WHERE Email ='" + detail.Email + "'", conn);
                    cmd.Parameters.AddWithValue("@LastLoginDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                    msg = "Successful";
                    cmd = new SqlCommand("select Type from Users Where Email ='" + detail.Email + "'", conn);
                    string type = cmd.ExecuteScalar().ToString();
                    return type;
                }
                else
                {
                    conn.Close();
                    msg = "Fail";
                }

                return msg;
            }
            catch (Exception e)
            {
                msg = "Error!!!";
                return msg;
            }
        }

        public DataSet Admin()
        {
            conn.Open();
            cmd = new SqlCommand("select * from Users", conn);
            cmd.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
    }
}