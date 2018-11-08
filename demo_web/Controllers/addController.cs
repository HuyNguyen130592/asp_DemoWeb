using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;

namespace demo_web.Controllers
{
    public class addController : Controller
    {
        private readonly object fileupload;

        // GET: add
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(FormCollection frm,HttpPostedFileBase img)
        {
            string a = frm["id"];
            string b = frm["name"];
            var filename = Path.GetFileName(img.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/img"),filename);
            img.SaveAs(path);
            string connect = @"Server =.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\demo_web.mdf;Database=demo_web;
Trusted_Connection=Yes";
            SqlConnection conn = new SqlConnection(connect);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = a;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@name";
            param2.Value = b;
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@img";
            param3.Value = filename;
            string command = "INSERT INTO demo (id,name,img) values(@id,@name,@img)";
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand(command, conn);
            sqlcommand.Parameters.Add(param);
            sqlcommand.Parameters.Add(param2);
            sqlcommand.Parameters.Add(param3);
            sqlcommand.ExecuteNonQuery();
            conn.Close();
            return View();
        }
        public ActionResult write()
        {
            string connect = @"Server =.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\demo_web.mdf;Database=demo_web;
Trusted_Connection=Yes";
            SqlConnection conn = new SqlConnection(connect);
            string command = "select * from demo";
            SqlDataAdapter da = new SqlDataAdapter(command, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "demo");
            DataTable tbl = ds.Tables["demo"];
            List<ListItem> selectlist = tbl.AsEnumerable().Select(n => new ListItem {Text=n.Field<string>("id"),Value=n.Field<string>("name") }).ToList();
            selectlist.Add(new ListItem { Text = "00", Value = "00", Selected = true });
            ViewBag.id = new SelectList(selectlist, "Text", "Value");
            return View();
        }
    }
}