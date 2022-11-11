namespace CLIENTES.ViewModel
{
    public partial class ClienteDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public byte Status { get; set; }
        public DateTime DataInclusao { get; set; }
        public ICollection<ClienteEnderecoDto>? ClienteEnderecos { get; set; }
    }
}
