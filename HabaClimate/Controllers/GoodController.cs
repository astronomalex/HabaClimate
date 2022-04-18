using System.Collections.Generic;
using System.Threading.Tasks;
using HabaClimate.Data.Interfaces;
using HabaClimate.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class GoodController : BaseApiController
    {
        private readonly IAllAirConditioners _conditionersRepository;

        public GoodController(IAllAirConditioners conditionersRepository)
        {
            _conditionersRepository = conditionersRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodDto>>> GetGoods()
        {
            var goods = await _conditionersRepository.AllGoodsAsync();

            if (goods == null) return BadRequest();

            return Ok(goods);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodDto>> GetGood(int id)
        {
            var good = await _conditionersRepository.GetGoodAsync(id);

            return good;
        }
    }
}