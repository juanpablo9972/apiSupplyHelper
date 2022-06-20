using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Detalle_Pedido.DTO
{
    public class DTOPedido
    {
        [Required]
        [DataType(DataType.Date)]
        public string Fecha { get; set; }
        [Required]
        public int CodigoPostal { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
