using System.ComponentModel.DataAnnotations;

namespace ExTI.Models
{
    public class CadClientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
}
