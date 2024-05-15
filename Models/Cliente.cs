using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bank.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        //public List<Ativo> Ativos { get; set; }
        public Cliente() { }
    }
}
