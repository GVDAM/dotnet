using AutoMapper;
using Gabriel.RentCar.Api.ViewModel;
using Gabriel.RentCar.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.Controllers
{
    [Route("api/scores")]
    public class ScoreController : MainCotroller
    {
        protected readonly IScoreRepository _scoreRepository;
        protected readonly IMapper _Mapper;

        public ScoreController(IScoreRepository scoreRepository,
                               IMapper mapper)
        {
            _Mapper = mapper;
            _scoreRepository = scoreRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreViewModel>> ObterTodosOsScores()
        {
            return _Mapper.Map<IEnumerable<ScoreViewModel>>(await _scoreRepository.ObterTodos());
        }

        [HttpGet("vendedor/{id:guid}")]
        public async Task<ActionResult<ScoreViewModel>> ObterScorePorVendedor(Guid id)
        {
            return _Mapper.Map<ScoreViewModel>(await _scoreRepository.ObterScorePorVendedor(id));   
        }

    }
}
