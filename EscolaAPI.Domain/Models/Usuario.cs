namespace EscolaAPI.Domain.Models
{
    public class Usuario : EntidadeBase
    {
        public string Nome {get; set;}
        public string Senha {get; set;}
        public string Cargo {get; set;}
        
    }
}