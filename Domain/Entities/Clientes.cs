using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CLIENTES")]
    public partial class Clientes : BaseEntity
    {
        [Required]
        [Column("NOME")]
        [StringLength(200)]
        public string Nome { get; set; }
        [Column("DT_NASCIMENTO", TypeName = "datetime")]
        public DateTime DtNascimento { get; set; }
        [Column("STATUS")]
        public byte Status { get; set; }
        [Column("DAT_INCLUSAO", TypeName = "datetime")]
        public DateTime DatInclusao { get; set; }

        public virtual ICollection<ClienteEnderecos> ClienteEnderecos { get; set; }
    }
}