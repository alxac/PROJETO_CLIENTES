using CLIENTES.ViewModel;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CLIENTES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClientesService _cliente;
        private IClienteEnderecosService _endereco;

        public ClientesController(IClientesService cliente, IClienteEnderecosService endereco)
        {
            _cliente = cliente;
            _endereco = endereco;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _cliente.SelectAllDataAsync());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _cliente.SelectByIdAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDto cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Clientes novo = new Clientes()
                {
                    Nome = cliente.Nome,
                    DatInclusao = cliente.DataInclusao,
                    DtNascimento = cliente.DtNascimento,
                    Status = cliente.Status
                };
                Clientes result = await _cliente.Post(novo);
                if (cliente.ClienteEnderecos != null)
                {
                    foreach (var endereco in cliente.ClienteEnderecos)
                    {
                        ClienteEnderecos enderecosNovo = new ClienteEnderecos()
                        {
                            IdCliente = result.Id,
                            Bairro = endereco.Bairro,
                            Cep = endereco.Cep,
                            Cidade = endereco.Cidade,
                            DatInclusao = endereco.DataInclusao,
                            Uf = endereco.Uf,
                            Logradouro = endereco.Logradouro,
                            Status = endereco.Status,
                            IdClienteNavigation = result
                        };
                        var resultEnd = await _endereco.Post(enderecosNovo);
                    }
                }

                if (result != null)
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClienteDto cliente)
        {
            List<ClienteEnderecos> enderecosNovos = new List<ClienteEnderecos>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //Preparando os dados
                Clientes alterar = new Clientes()
                {
                    Id = (int)cliente.Id,
                    Nome = cliente.Nome,
                    DatInclusao = DateTime.UtcNow,
                    DtNascimento = cliente.DtNascimento,
                    Status = cliente.Status
                };
                if (cliente.ClienteEnderecos != null)
                {
                    foreach (var endereco in cliente.ClienteEnderecos)
                    {
                        ClienteEnderecos enderecosNovo = new ClienteEnderecos()
                        {
                            Id = endereco.Id,
                            IdCliente = (int)cliente.Id,
                            Bairro = endereco.Bairro,
                            Cep = endereco.Cep,
                            Cidade = endereco.Cidade,
                            DatInclusao = DateTime.UtcNow,
                            Uf = endereco.Uf,
                            Logradouro = endereco.Logradouro,
                            Status = endereco.Status,
                            IdClienteNavigation = alterar
                        };
                        enderecosNovos.Add(enderecosNovo);
                    }
                }
                alterar.ClienteEnderecos = enderecosNovos;
                //Banco
                Clientes result = await _cliente.Put(alterar);
                int idCliente = result.Id;
                if (cliente.ClienteEnderecos != null)
                {
                    foreach (var endereco in alterar.ClienteEnderecos)
                    {
                        ClienteEnderecos enderecosNovo = new ClienteEnderecos()
                        {
                            IdCliente = idCliente,
                            Bairro = endereco.Bairro,
                            Cep = endereco.Cep,
                            Cidade = endereco.Cidade,
                            DatInclusao = DateTime.UtcNow,
                            Uf = endereco.Uf,
                            Logradouro = endereco.Logradouro,
                            Status = endereco.Status,
                            IdClienteNavigation = result
                        };
                        ClienteEnderecos resultEnd = new ClienteEnderecos();
                        if (endereco.Id > 0)
                        {
                            enderecosNovo.Id = endereco.Id;
                            var r = _endereco.Put(enderecosNovo).Result;
                        }
                        else
                        {
                            var r = _endereco.Post(enderecosNovo).Result;
                        }
                    }
                }
                else
                {
                    await _endereco.DeleteByClientId(result.Id);
                }
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var endereco = await _endereco.DeleteByClientId(id);
                return Ok(await _cliente.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
