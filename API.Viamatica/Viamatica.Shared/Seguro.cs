using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viamatica.Shared
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Seguro
    {
        [Key]
        public int IdSeguro { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public decimal SumaAsegurada { get; set; }
        public decimal Prima { get; set; }

        //para relacion muchos a muchos
        public ICollection<AseguradoSeguro>? AseguradoSeguros { get; set; }

    }
}
