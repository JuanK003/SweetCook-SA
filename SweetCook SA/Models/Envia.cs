using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("Envia")]
    public class Envia
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreEnvio { get; set; }
        public int CantidadEnvia { get; set; }
        public DateTime Fecha { get; set; }

        // Recibe llaves primarias
        public Producto TablaProducto { get; set; }
        public int ProductoId { get; set; }
        //-------------------------------------------
        public Sucursal TablaSucursal { get; set; }
        public int SucursalId { get; set; }
        //-------------------------------------------
        public DepartamentoRecibe TablaDepartamentoRecibe { get; set; }
        public int DepartamentoRecibeId { get; set; }

        // Envia llave primaria
        public ICollection<Recibe> TablaRecibe { get; set; }
    }
}