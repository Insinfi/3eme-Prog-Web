using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionEtudian_OMG_WHAT_A_EXERCICE.Controllers
{
    public class HomeController : Controller
    {
        public List<Models.Etudiant> ListeMatricules = new List<Models.Etudiant>();
        // GET: Home

        public ActionResult Index()
        {
            GetAllMatricules();
            return View(ListeMatricules);
        }

        public JsonResult GetStudentInfo(string id)
        {
            string ConnectionStr = @"Server=127.0.0.1\SQLEXPRESS;Database=dbCours20172018;Uid=Cours2018;Pwd=password;";
            SqlConnection MyConnection = new SqlConnection(ConnectionStr);
            MyConnection.Open();

            SqlCommand MyCmd = new SqlCommand();
            MyCmd.Connection = MyConnection;
            MyCmd.CommandType = System.Data.CommandType.StoredProcedure;
            MyCmd.CommandText = "GetStudentInfo";
            MyCmd.Parameters.AddWithValue("@Matricule", id);
            SqlDataReader MyRd = MyCmd.ExecuteReader();
            MyRd.Read();
            Models.Etudiant etud = new Models.Etudiant { Nom = MyRd["Nom"].ToString(), Prenom = MyRd["Prenom"].ToString(), Localite = MyRd["Localite"].ToString() };
            MyRd.Close();
            MyConnection.Close();

            return Json(etud);
        }
        public void GetAllMatricules()
        {
            string ConnectionStr =@"Server=127.0.0.1\SQLEXPRESS;Database=dbCours20172018;Uid=Cours2018;Pwd=password;";
            SqlConnection MyConnection = new SqlConnection(ConnectionStr);
            MyConnection.Open();

            SqlCommand MyCmd = new SqlCommand();
            MyCmd.Connection = MyConnection;
            MyCmd.CommandType = System.Data.CommandType.StoredProcedure;
            MyCmd.CommandText = "GetAllMatricules";

            SqlDataReader MyRd = MyCmd.ExecuteReader();
            while (MyRd.Read()) {
                ListeMatricules.Add(new Models.Etudiant { Matricule = MyRd["Matricule"].ToString() });
            }
            MyRd.Close();
            MyConnection.Close();
        }
    }
}