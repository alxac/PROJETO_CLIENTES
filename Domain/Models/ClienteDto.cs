namespace CLIENTES.Models
{
    public partial class ClienteDto
    {
        public string Nome { get; set; }

        public DateTime DtNascimento { get; set; }

        public byte Status { get; set; }
        public DateTime DataInclusao { get; set; }

        public ICollection<ClienteEnderecoDto>? ClienteEnderecos { get; set; }
    }
}
