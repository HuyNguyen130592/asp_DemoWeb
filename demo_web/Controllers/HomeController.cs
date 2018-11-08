using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo_web.Models;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;


namespace demo_web.Controllers
{
    public class HomeController : Controller
    {
         
       

        public ActionResult Index()
        {
//             string connect = @"Server =.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\demo_web.mdf;Database=demo_web;
//Trusted_Connection=Yes";
//              string command = @"SELECT * from demo";
//             SqlConnection conn = new SqlConnection(connect);
//             SqlCommand sqlcommand;
//            DataSet ds = new DataSet();
//             SqlDataAdapter da = new SqlDataAdapter(command, conn);
//            da.Fill(ds, "product");
//            DataTable tblpro = ds.Tables["product"];
            //IEnumerable<product> query = tblpro.AsEnumerable().Select(n => new product {price=n.Field<int>("price") });
            //foreach(IEnumerable<product> u in query)
            //{
                
            //}
            return View();
        }
        public ActionResult ThanhPhan()
        {
            return PartialView();
        }
    }
}