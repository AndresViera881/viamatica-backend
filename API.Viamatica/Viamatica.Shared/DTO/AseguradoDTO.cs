using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viamatica.Shared.DTO
{
    public class AseguradoDTO
    {
        public int Id { get; set; }
        public String? Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? Telefono { get; set; }
        public int Edad { get; set; }
        public List<Seguro>? Seguros { get; set; }
    }
}
