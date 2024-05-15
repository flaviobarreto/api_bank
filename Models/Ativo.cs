using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_bank.Models
{
    public class Ativo
    {
        public int AtivoId { get; set; }
        [Required]
        public string AtivoName { get; set; }
        [Required]
        public double Preco {get; set; }
        public List<Cliente> clientes { get; set; }
    }
}
