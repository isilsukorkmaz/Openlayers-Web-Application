using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using BasarsoftOpenLayers.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySql.Web.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BasarsoftOpenLayers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {         
            return View();
        }

        [HttpPost]
        public JsonResult GetDistricts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM mahalle";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("Districts");
            adp.Fill(dt);
            adp.Dispose();
            cmd.Dispose();
            con.Close();
            var responce = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            return Json(responce);
        }

        [HttpPost]
        public JsonResult GetDoors()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM kapı";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("Doors");
            adp.Fill(dt);
            adp.Dispose();
            cmd.Dispose();
            con.Close();
            var responce = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            return Json(responce);
        }


        [HttpPost]
        public JsonResult InsertDistrict(Mahalle mahalle)
        {
            string query = "INSERT INTO mahalle(mahalleAdı,koordinat) VALUES(@mahalleAdı,@koordinat)";
           // query += "SELECT SCOPE_IDENTITY()";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
          
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@mahalleAdı", mahalle.mahalleAdı);
                    cmd.Parameters.AddWithValue("@koordinat", mahalle.koordinat.Trim());
                    cmd.Connection = con;
                    con.Open();                   
                    mahalle.mahalleKodu = Convert.ToInt32(cmd.ExecuteScalar());
                    //MessageBox.Show(mahalle.mahalleKodu.ToString());
                    con.Close();
                }
            }
            return Json(mahalle);
        }

        [HttpPost]
        public JsonResult UpdateDistrict(Mahalle mahalle)
        {
            string query = "UPDATE mahalle SET mahalleAdı=@mahalleAdı, koordinat=@koordinat WHERE mahalleKodu=@mahalleKodu";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                   
                    cmd.Parameters.AddWithValue("@mahalleKodu", mahalle.mahalleKodu);
                    cmd.Parameters.AddWithValue("@mahalleAdı", mahalle.mahalleAdı);
                    cmd.Parameters.AddWithValue("@koordinat", mahalle.koordinat);
                    cmd.Connection = con;
                    con.Open();
                    //mahalle.mahalleKodu = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.ExecuteNonQuery();
                    con.Close();
                   
                }
            }

            return Json(mahalle);
        }

        [HttpPost]
        public JsonResult InsertDoor(Kapı kapı)
        {
            string query = "INSERT INTO kapı(kapıNo,mahalleKodu,koordinat) VALUES(@kapıNo,@mahalleKodu,@koordinat)";
            // query += "SELECT SCOPE_IDENTITY()";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {

                    cmd.Parameters.AddWithValue("@kapıNo", kapı.kapıNo);
                    cmd.Parameters.AddWithValue("@mahalleKodu", kapı.mahalleKodu);
                    cmd.Parameters.AddWithValue("@koordinat", kapı.koordinat.Trim());
                    cmd.Connection = con;
                    con.Open();
                    // mahalle.mahalleKodu = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.ExecuteNonQuery();
                   con.Close();
                }
            }
            return Json(kapı);
        }
        [HttpPost]
        public JsonResult UpdateDoor(Kapı kapı)
        {
            string query = "UPDATE kapı SET koordinat=@koordinat WHERE mahalleKodu=@mahalleKodu AND kapıNo=@kapıNo";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    //MessageBox.Show(""+kapı.mahalleKodu);
                    cmd.Parameters.AddWithValue("@mahalleKodu", kapı.mahalleKodu);
                    cmd.Parameters.AddWithValue("@kapıNo", kapı.kapıNo);
                    cmd.Parameters.AddWithValue("@koordinat", kapı.koordinat);
                    cmd.Connection = con;
                    con.Open();
                    //mahalle.mahalleKodu = Convert.ToInt32(cmd.ExecuteScalar());
                    //cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            return Json(kapı);
        }

        [HttpPost]
        public ActionResult DeleteDistrict(int mahalleKodu)
        {            
            string query = "DELETE FROM mahalle WHERE mahalleKodu=@mahalleKodu";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@mahalleKodu", mahalleKodu);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteDoor(int kapıNo, int mahalleKodu)
        {
            string query = "DELETE FROM kapı WHERE kapıNo=@kapıNo and mahalleKodu=@mahalleKodu";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@kapıNo", kapıNo);
                    cmd.Parameters.AddWithValue("@mahalleKodu", mahalleKodu);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteDoorsForDistr(int mahalleKodu)
        {
            string query = "DELETE FROM kapı WHERE mahalleKodu=@mahalleKodu";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {                  
                    cmd.Parameters.AddWithValue("@mahalleKodu", mahalleKodu);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return new EmptyResult();
        }

        

        [HttpPost]
        public JsonResult Search(string mahalleAdı,string kapıNo)
        {    
            //MessageBox.Show(kapıNo);        
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.Parameters.AddWithValue("@mahalleAdı", mahalleAdı);
            cmd.Parameters.AddWithValue("@kapıno", kapıNo); 

            if (kapıNo.Length == 0)
            {
                
                cmd.CommandText = "SELECT kapı.kapıNo, mahalle.mahalleAdı, kapı.koordinat FROM kapı JOIN mahalle ON kapı.mahalleKodu=mahalle.mahalleKodu WHERE mahalle.mahalleAdı=@mahalleAdı ORDER BY kapı.kapıNo ASC;";
            }
            else
            {
                           
                cmd.CommandText = "SELECT kapı.kapıNo, mahalle.mahalleAdı, kapı.koordinat FROM kapı JOIN mahalle ON kapı.mahalleKodu=mahalle.mahalleKodu WHERE mahalle.mahalleAdı=@mahalleAdı AND kapı.kapıNo=@kapıno ORDER BY kapı.kapıNo ASC;";
            }

            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            adp.Dispose();
            cmd.Dispose();
            con.Close();

            var responce = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            return Json(responce);
        }
       

    }
}