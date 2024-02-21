using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Inventario
    {
        public int Id { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string FechaAdquision { get; set; }
        public string TipoAdquision { get; set; }
        public string Observaciones { get; set; }
        public int Areas_id { get; set; }

        // Constructor sin parámetros
        public Inventario()
        {
            Id = 0;
            NombreCorto = "";
            Descripcion = "";
            Serie = "";
            Color = "";
            FechaAdquision = "";
            TipoAdquision = "";
            Observaciones = "";
            Areas_id = 0;
        }

        // Constructor con parámetros
        public Inventario(int id, string nombreCorto, string descripcion, string serie, string color,
            string fechaAdquision, string tipoAdquision, string observaciones, int areas_id)
        {
            Id = id;
            NombreCorto = nombreCorto;
            Descripcion = descripcion;
            Serie = serie;
            Color = color;
            FechaAdquision = fechaAdquision;
            TipoAdquision = tipoAdquision;
            Observaciones = observaciones;
            Areas_id = areas_id;
        }
    }
}
