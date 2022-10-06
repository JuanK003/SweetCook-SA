using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreProducto { get; set; }
        [MaxLength(4096)]
        public string Descripcion { get; set; }

        // Envia llave primaria
        public ICollection<Envia> TablaEnvia { get; set; }
    }
}