using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyUnsplash.Models;
using System.IO;

namespace MyUnsplash.Controllers
{
    public class HomeController : Controller
    {
        string CS = ConfigurationManager.ConnectionStrings["DC"].ConnectionString;
        
        public ActionResult Index()
        {
            ViewBag.Image = GetTodos();
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "Id, Label, UrlFile")] Image Image)
        {
            if (ModelState.IsValid)
            {
                Save(Image);
                ViewBag.Image = GetTodos();
                return RedirectToAction("Index");
                
            }
            Save(Image);
            ViewBag.Image = GetTodos();
            return View();
        }
        
        public ActionResult Delete(Guid id)
        {
            //DeleteImage(id);
            return RedirectToAction("Listagem");
        }
        public void DeleteImage(Guid Id)
        {
            using (SqlConnection sqlCon = new SqlConnection(CS))
            {
                sqlCon.Open();
                string query = "Delete from Image Where Id=@Id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.ExecuteNonQuery();
            }
        }
        public void Save(Image model)
        {
            model.Id = Guid.NewGuid();
            using (SqlConnection sqlCon = new SqlConnection(CS))
            {
                sqlCon.Open();
                string query = "INSERT INTO Image VALUES(@Id, @Label, @UrlFile, @DataRegistro)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", model.Id);
                sqlCmd.Parameters.AddWithValue("@Label", model.Label);
                sqlCmd.Parameters.AddWithValue("@UrlFile", model.UrlFile);
                sqlCmd.Parameters.AddWithValue("@DataRegistro", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
            }
        }
        public List<Image> GetTodos()
        {
            List<Image> ImageL = new List<Image>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("  SELECT * FROM Image ORDER BY DataRegistro DESC", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Image = new Image();
                    Image.Id = Guid.Parse(rdr["Id"].ToString());
                    Image.Label = rdr["Label"].ToString();
                    Image.UrlFile = rdr["UrlFile"].ToString();
                    ImageL.Add(Image);
                }
            }

            return ImageL;
        }
    }
}