using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models
{
    [Table("Tipousuario")]

    public class Tipousuario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Escreva o seu tipo usuário!")]
        [Display(Name = "tipo usuário")]
        public string Nome { get; set; }

    }
}