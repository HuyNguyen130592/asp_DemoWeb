using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using demo_web.Models;

namespace demo_web.Controllers
{
    public class sanphamController : Controller
    {
        // GET: sanpham
        public ActionResult Index()
        {
            string connect = @"Server =.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\demo_web.mdf;Database=demo_web;
Trusted_Connection=Yes";
            string command1 = @"select * from type ";
            string command2 = @"select * from sp ";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da1 = new SqlDataAdapter(command1,conn);
            SqlDataAdapter da2 = new SqlDataAdapter(command2, conn);
            DataSet ds = new DataSet();
            da1.Fill(ds, "type");
            da2.Fill(ds, "sp");
            List<type> tbltype = ds.Tables["type"].AsEnumerable().Select(n => new type {id=n.Field<string>("id"),name=n.Field<string>("name") }).ToList();
                                            
            List<sp> tblsp = ds.Tables["sp"].AsEnumerable().Select(n => new sp { id = n.Field<string>("id"), name = n.Field<string>("name"), id_type = n.Field<string>("id_type") }).ToList();
            ViewBag.sp = tblsp;
            return View(tbltype);
        }
    }
}