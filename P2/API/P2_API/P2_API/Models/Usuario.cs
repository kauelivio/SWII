using System.ComponentModel.DataAnnotations;

namespace P2_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
