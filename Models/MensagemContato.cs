namespace RICARDOAPI.API.Models
{
    public class MensagemContato
    {
        public int Id { get; set; } // Identificador único para a mensagem
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
