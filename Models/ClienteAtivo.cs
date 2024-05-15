using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bank.Models
{
    public class ClienteAtivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteAtivoId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int AtivoId  { get; set; }
        [Required]
        public int Quantidade { get; set; }

       // public Cliente  Cliente { get; set; }
       //public Ativo Ativo  { get; set; }
    }
}
