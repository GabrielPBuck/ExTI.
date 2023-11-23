using System.ComponentModel.DataAnnotations;

namespace ExTI.Models
{
    public class CadMaquinas
    {
        [Key]
        public int IdMaquina { get; set; }
        public int Patrimonio { get; set; }
        public string Memoria { get; set; }
        public string HD { get; set; }

    }
}
