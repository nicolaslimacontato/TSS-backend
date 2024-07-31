using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models
{
    [Table("Tiposervico")]

    public class Tiposervico
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Escreva o seu tipo do serviço!")]
        [Display(Name = "tipo do serviço")]
        public string Nome { get; set; }

    }
}