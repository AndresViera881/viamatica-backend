using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Viamatica.Shared
{

    [Index(nameof(Cedula), IsUnique = true)]
    public class Asegurado
    {
        [Key]
        public int IdAsegurado { get; set; }
        public String? Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? Telefono { get; set; }
        public int Edad { get; set; }

        //para relacion muchos a muchos
        public ICollection<AseguradoSeguro>? AseguradosSeguros { get; set; }
    }
}
