namespace CLIENTES.ViewModel
{
    public partial class ClienteEnderecoDto
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string Logradouro { get; set; }

        public string Cep { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public byte Status { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
