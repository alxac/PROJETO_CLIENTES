using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("CLIENTE_ENDERECOS")]
    public partial class ClienteEnderecos : BaseEntity
    {
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }
        [Required]
        [Column("LOGRADOURO")]
        [StringLength(100)]
        public string Logradouro { get; set; }
        [Required]
        [Column("CEP")]
        [StringLength(8)]
        public string Cep { get; set; }
        [Required]
        [Column("UF")]
        [StringLength(2)]
        public string Uf { get; set; }
        [Required]
        [Column("CIDADE")]
        [StringLength(100)]
        public string Cidade { get; set; }
        [Required]
        [Column("BAIRRO")]
        [StringLength(60)]
        public string Bairro { get; set; }
        [Column("STATUS")]
        public byte Status { get; set; }
        [Column("DAT_INCLUSAO", TypeName = "datetime")]
        public DateTime DatInclusao { get; set; }

        [JsonIgnore]
        public virtual Clientes IdClienteNavigation { get; set; }
    }
}