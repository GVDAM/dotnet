using AutoMapper;
using Gabriel.RentCar.Api.ViewModel;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.Controllers
{
    [Route("api/clientes")]
    public class ClientesController : MainCotroller
    {
        protected readonly IClienteRepository _clienteRepository;
        protected readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository,
                                 IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterClientePorId(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> AdicionarCliente(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var cliente = await _clienteRepository.ObterPorId(clienteViewModel.Id);

            if (cliente != null) return BadRequest("Cliente já existente. Informar ID único, por favor");

            await _clienteRepository.Adicionar(_mapper.Map<Cliente>(clienteViewModel));
            
            return Ok(clienteViewModel.Nome + " foi adicionado com sucesso");

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> AtualizarCliente(Guid? id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return BadRequest("Id informado é diferente do Body");
            if (id == null) return BadRequest("Por favor informe um ID");
            if (!ModelState.IsValid) return BadRequest();

            //VALIDAÇÃO DE CLIENTE NÃO EXISTENTE
            //var cliente = await _clienteRepository.ObterPorId(clienteViewModel.Id);
            //if (cliente == null) return NotFound("Cliente informado não existe. Solicitar Cliente com ID existente");

            await _clienteRepository.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return Ok(new
            {
                success = true,
                data = clienteViewModel
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> RemoverCliente(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();
            // VALIDAÇÃO PARA CASO O ID NÃO EXISTIR NO BANCO
            await _clienteRepository.Remover(id);
            return Ok(new
            {
                success = true,
                Cliente = id
            });
        }
    }
}
