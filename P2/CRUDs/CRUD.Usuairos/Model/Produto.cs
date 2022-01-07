using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Usuairos.Model
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public float Preco { get; set; }
        public bool Status { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public int IdUsuarioUpdate { get; set; }

    }
}
