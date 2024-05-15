using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bank.Models
{
    public class Ativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtivoId { get; set; }
        [Required]
        public string AtivoName { get; set; }
        [Required]
        public double Preco {get; set; }
        //public List<Cliente> clientes { get; set; }
    }
}
