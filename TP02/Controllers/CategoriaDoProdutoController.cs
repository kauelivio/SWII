//Kauê de Jesus Livio CB3005461
//Pedro Paulo dos Reis Faria CB3007278

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPR2.Models;

namespace TPR2.Controllers
{
    public class CategoriaDoProdutoController : Controller
    {
        // GET: CategoriaDoProduto

        List<CategoriaDoProduto> categorias = new List<CategoriaDoProduto>();
        public ActionResult Index()
        {

            var conn = new SqlConnection(@"Server=.\sqlexpress;Database=TPR2;Trusted_Connection=True;");

            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "select * from categoria";
            var data = command.ExecuteReader();

            while (data.Read())
            {
                categorias.Add(new CategoriaDoProduto() { Id = (int)data["ID"], Nome = data["Nome"].ToString(), Descricao = data["Descricao"].ToString() });
            }

            conn.Close();
            return View(categorias);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(CategoriaDoProduto categoria)
        {

            var conn = new SqlConnection(@"Server=.\sqlexpress;Database=TPR2;Trusted_Connection=True;");

            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "insert into categoria(Nome, Descricao)values(@Nome, @Descricao)";
            command.Parameters.AddWithValue("Nome", categoria.Nome);
            command.Parameters.AddWithValue("Descricao", categoria.Descricao);

            command.ExecuteNonQuery();

            conn.Close();

            categorias.Add(categoria);
            return View("Index", categorias);
        }
    }
}