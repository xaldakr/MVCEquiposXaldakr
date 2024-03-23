using System.ComponentModel.DataAnnotations;

namespace MVCEquiposXaldakr.Models
{
    public class equipos
    {
        [Key]
        public int id_equipos { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int? tipo_equipo_id { get; set; }
        public int? marca_id { get; set; }
        public string modelo { get; set; }
        [Range(2010, 2099, ErrorMessage ="Los valores aceptados son entre 2010 y 2099!")]
        public int? anio_compra { get; set; }
        public decimal costo { get; set; }
        public int? vida_util { get; set; }
        public int? estado_equipo_id { get; set; }
        public char estado { get; set; }
    }
}
