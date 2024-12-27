using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Data;
using ReactAppApi.Server.DTOs.StockDto;
using ReactAppApi.Server.Interfaces;
using ReactAppApi.Server.Mappers.StockMappers;

namespace ReactAppApi.Server.Controllers
{

    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;

        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;

        }


        //No C#, o padrão Repository é usado para abstrair e encapsular o acesso aos dados em aplicações.
        //Ele é uma camada intermediária entre a lógica de negócio e a fonte de dados (como um banco de dados).
        //Essa abordagem segue os princípios do Domain-Driven Design
        //(DDD) e ajuda a criar sistemas modulares, testáveis e fáceis de manter.

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stocks = await _stockRepo.GetAllAsync();
            return Ok(stocks);

            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stocks = await _stockRepo.GetByIdAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stockModel = await _stockRepo.UpdateByIdAsync(id, updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stockModel = await _stockRepo.DeleteByIdAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }



            return NoContent();
        }

    }
}
