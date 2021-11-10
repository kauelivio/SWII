//Kauê de Jesus Livio CB3005461
//Pedro Paulo dos Reis Faria CB3007278

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPR2.Models;

namespace TPR2.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto

        List<Produto> produtos = new List<Produto>();
        public ActionResult Index()
        {

            var conn = new SqlConnection(@"Server=.\sqlexpress;Database=TPR2;Trusted_Connection=True;");

            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "select * from produto";
            var data = command.ExecuteReader();

            while (data.Read())
            {
                produtos.Add(new Produto() { Id = (int)data["ID"], Nome = data["Nome"].ToString(), Preco = (int)data["Preco"], Descricao = data["Descricao"].ToString(), Quantidade = (int)data["Quantidade"] });
            }

            conn.Close();
            return View(produtos);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Produto produto)
        {

            var conn = new SqlConnection(@"Server=.\sqlexpress;Database=TPR2;Trusted_Connection=True;");

            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "insert into produto(Nome, Preco, Descricao, Quantidade)values(@Nome, @Preco, @Descricao, @Quantidade)";
            command.Parameters.AddWithValue("Nome", produto.Nome);
            command.Parameters.AddWithValue("Preco", produto.Preco);
            command.Parameters.AddWithValue("Descricao", produto.Descricao);
            command.Parameters.AddWithValue("Quantidade", produto.Quantidade);
            command.ExecuteNonQuery();

            conn.Close();

            produtos.Add(produto);
            return View("Index", produtos);
        }

    }
}