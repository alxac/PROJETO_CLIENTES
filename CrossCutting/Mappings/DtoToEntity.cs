using AutoMapper;
using CLIENTES.Models;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class DtOToModelProfile : Profile
    {
        public DtOToModelProfile()
        {
            CreateMap<Clientes, ClienteDto>().ReverseMap();
            CreateMap<ClienteEnderecos, ClienteEnderecoDto>().ReverseMap();
        }
    }
}
