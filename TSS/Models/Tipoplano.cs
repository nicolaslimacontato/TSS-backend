using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models
{
    [Table("Tipoplano")]

    public class Tipoplano
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Escreva o seu tipo de plano!")]
        [Display(Name = "tipo de plano")]
        public string Nome { get; set; }

    }
}