//Kauê de Jesus Livio CB3005461
//Pedro Paulo dos Reis Faria CB3007278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPR2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public float Preco { get; set; }
        public CategoriaDoProduto Categoria { get; set; }
        public int? CategoriaID { get; set; }
        public String Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}