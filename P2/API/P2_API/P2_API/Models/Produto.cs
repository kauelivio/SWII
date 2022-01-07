using System.ComponentModel.DataAnnotations;

namespace P2_API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public float Preco { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int IdUsuarioCadastro { get; set; }
        public int? IdUsuarioUpdate { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
