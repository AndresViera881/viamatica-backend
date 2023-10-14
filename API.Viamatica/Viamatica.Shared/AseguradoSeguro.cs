
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viamatica.Shared
{
    public class AseguradoSeguro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("Asegurado")]
        public int IdAsegurado { get; set; }
        [ForeignKey("Seguro")]
        public int IdSeguro { get; set; }
        public Asegurado? Asegurado { get; set; }
        public Seguro? Seguro { get; set; }
    }
}
