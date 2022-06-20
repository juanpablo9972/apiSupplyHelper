using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.DetalleProveedor.DTO
{
    public class DTOProductoProveedor
    {
        [Required]
        public double precioUnitario { get; set; }
        [Required]
        public double pesoUnitario { get; set; }
        [Required]
        public double cantidadMinima { get; set; }
        [Required]
        public string unidadMedida { get; set; }
        [Required]
        public string Presentacion { get; set; }
        [Required]
        public int ProveedorId { get; set; }
        [Required]
        public int ProductoId { get; set; }
    }
}
