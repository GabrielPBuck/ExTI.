using System.ComponentModel.DataAnnotations;

namespace ExTI.Models
{
    public class InventarioModel
    {
        [Key]
        public int IdInventario { get; set; }
        public int IdCliente { get; set; }
        public int IdMaquina { get; set; }
        public string Valor { get; set; }
        public  int Quantidade { get; set; }

        public List<CadClientes> ListaClientes { get; set; }
        public List<CadMaquinas> ListaMaquinas { get; set; }


    }
}
