using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models
{
    [Table("Tipocontato")]

    public class Tipocontato
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Escreva o seu tipo de contato!")]
        [Display(Name = "tipo de contato")]
        public string Nome { get; set; }

    }
}