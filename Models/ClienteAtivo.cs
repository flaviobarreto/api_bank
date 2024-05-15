namespace api_bank.Models
{
    public class ClienteAtivo
    {
        public int ClienteAtivoId { get; set; }
        public int ClienteId { get; set; }
        public int AtivoId  { get; set; }
        public Cliente  Cliente { get; set; }
        public Ativo Ativo  { get; set; }
    }
}
