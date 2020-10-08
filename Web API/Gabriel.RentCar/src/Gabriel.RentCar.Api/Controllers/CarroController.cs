using AutoMapper;
using Gabriel.RentCar.Api.ViewModel;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.Controllers
{
    [Route ("api/carros")]
    public class CarroController : MainCotroller
    {
        protected readonly ICarroRepository _carroRepository;
        protected readonly IVendaRepository _vendaRepository;
        protected readonly IMapper _mapper;

        public CarroController(ICarroRepository carroRepository,
                               IVendaRepository vendaRepository,
                               IMapper mapper)
        {
            _carroRepository = carroRepository;
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<CarroViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CarroViewModel>> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var carro = await _carroRepository.ObterPorId(id);

            if (carro == null) return NoContent();

            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult<CarroViewModel>> AdicionarCarro(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var carro = await _carroRepository.ObterPorId(carroViewModel.Id);

            if (carro != null) return BadRequest("Carro já existente. Informar ID único, por favor");

            await _carroRepository.Adicionar(_mapper.Map<Carro>(carroViewModel));

            return Ok(carroViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CarroViewModel>> AtualizarCarro(Guid id, CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (id != carroViewModel.Id) return BadRequest("ID da URL está diferente do Body");

            await _carroRepository.Atualizar(_mapper.Map<Carro>(carroViewModel));
            return Ok(new
            {
                success = true,
                mensagem = "Carro atualizado com sucesso",
                data = carroViewModel
            });

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CarroViewModel>> ExcluirCarro(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var carroVenda = await _vendaRepository.ObterPorIdCarro(id);
            if (carroVenda != null)
                return BadRequest(new
                {
                    mensagem = "O carro já não pode ser excluído quando já está vendido",
                    data = carroVenda
                });
                
            await _carroRepository.Remover(id);
            return Ok(id);
        }


        //Finalizar o Método ObterAtivos()
        [HttpGet("{ativos}")]
        public async Task<IEnumerable<CarroViewModel>> ObterAtivos()
        {
            var carros = new Carro();
            return _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterAtivos(carros));
        }

    }
}
