using System.Collections.Generic;

namespace api_bank.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public List<Ativo> Ativos { get; set; }
        public Cliente() { }
    }
}
