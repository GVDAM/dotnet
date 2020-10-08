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
    [Route("api/vendedores")]
    public class VendedorController : MainCotroller
    {
        protected readonly IVendedorRepository _vendedorRepository;
        protected readonly IMapper _Mapper;

        public VendedorController(IVendedorRepository vendedorRepository,
                                  IMapper mapper)
        {
            _Mapper = mapper;
            _vendedorRepository = vendedorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<VendedorViewModel>> ObterTodosOsVendedores()
        {
            return _Mapper.Map<IEnumerable<VendedorViewModel>>(await _vendedorRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<VendedorViewModel>>> ObterVendedorPorId(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var vendedor = await _vendedorRepository.ObterPorId(id);

            if (vendedor == null) return NoContent();

            return Ok(vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<VendedorViewModel>> AdicionarNovoVendedor(VendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var vendedor = await _vendedorRepository.ObterPorId(vendedorViewModel.Id);

            if (vendedor != null) return BadRequest("Vendedor já existente. Adicionar ID único, por favor.");

            await _vendedorRepository.Adicionar(_Mapper.Map<Vendedor>(vendedorViewModel));

            return Ok(vendedorViewModel);


        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VendedorViewModel>> AtualizarVendedor(Guid id, VendedorViewModel vendedorViewModel)
        {
            if (id != vendedorViewModel.Id) return Conflict("Id do Header é diferente do Body");
            if (!ModelState.IsValid) return BadRequest();

            await _vendedorRepository.Atualizar(_Mapper.Map<Vendedor>(vendedorViewModel));
            return Ok(vendedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VendedorViewModel>> ExcluirVendedor(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var vendedorViewModel = await ObterVendedorScore(id);

            if (vendedorViewModel == null) return NoContent();

            await _vendedorRepository.Remover(id);

            return Ok(vendedorViewModel);

        }
                
        [HttpGet("score/{id:guid}")]
        public async Task<VendedorViewModel> ObterVendedorScore(Guid id)
        {
            return _Mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterVendedorScore(id));
        }
        

    }
}

