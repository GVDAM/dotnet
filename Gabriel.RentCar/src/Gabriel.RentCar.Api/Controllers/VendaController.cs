using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Api.ViewModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace Gabriel.RentCar.Api.Controllers
{
    [Route ("api/vendas")]
    public class VendaController : MainCotroller
    {
        protected readonly IVendedorRepository _vendedorRepository;
        protected readonly IClienteRepository _clienteRepository;
        protected readonly IVendaRepository _vendaRepository;                
        protected readonly ICarroRepository _carroRepository;
        protected readonly IMapper _mapper;

        public VendaController(IVendaRepository vendaRepository,
                               ICarroRepository carroRepository,
                               IClienteRepository clienteRepository,
                               IVendedorRepository vendedorRepository,
                               IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _carroRepository = carroRepository;
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<VendaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(await _vendaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VendaViewModel>> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var venda = await _vendaRepository.ObterPorId(id);
            if (venda == null) return NoContent();

            return Ok(_mapper.Map<VendaViewModel>(venda));
        }

        [HttpPost]
        public async Task<ActionResult<VendaViewModel>> AdicionarVenda(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var venda = await _vendaRepository.ObterPorId(vendaViewModel.Id);

            if (venda != null) return BadRequest("Venda já Cadastrada. Informe um ID único, por favor!!");

            //if (!ValidarDados(vendaViewModel)) return BadRequest("Há infromações erradas na venda. Confira os IDs do carro, vendedor, cliente");
            var carro = await _carroRepository.ObterPorId(vendaViewModel.CarroId);
            if (carro == null) return BadRequest("Id do Carro não é válido");

            var vendedor = await _vendedorRepository.ObterPorId(vendaViewModel.VendedorId);
            if (vendedor == null) return BadRequest("Id do Vendedor não é válido");

            var cliente = await _clienteRepository.ObterPorId(vendaViewModel.ClienteId);
            if (cliente == null) return BadRequest("Id do Cliente não é válido");

            await _vendaRepository.Adicionar(_mapper.Map<Venda>(vendaViewModel));
            return Ok(vendaViewModel);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VendaViewModel>> AtualizarVenda(Guid id, VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (id != vendaViewModel.Id) return BadRequest("ID do HEADER não confere com o BODY");

            await _vendaRepository.Atualizar(_mapper.Map<Venda>(vendaViewModel));
            return Ok(vendaViewModel);

        }

        /*
        public async bool ValidarDados(VendaViewModel vendaViewModel)
        {   
            var carro = await _carroRepository.ObterPorId(vendaViewModel.CarroId);
            if (carro == null) return false;

            var vendedor = await _vendedorRepository.ObterPorId(vendaViewModel.VendedorId);
            if (vendedor == null) return false;

            var cliente = await _clienteRepository.ObterPorId(vendaViewModel.ClienteId);
            if (cliente == null) return false;

            return true;
        }
        */

             
    }
}
