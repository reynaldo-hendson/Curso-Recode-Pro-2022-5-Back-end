using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia.Models
{
    [Table("Destinos")]
    public class Destino
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? CidadeNome { get; set; }

        [Required]
        [StringLength(5)]
        public string? Pais { get; set; }
       
    }
}
