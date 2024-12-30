using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Data;
using ReactAppApi.Server.DTOs.StockDto;
using ReactAppApi.Server.Helpers;
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


        //In C#, the Repository pattern is used to abstract and encapsulate data access in applications.
        //It acts as an intermediary layer between the business logic and the data source (such as a database).
        //This approach follows the principles of Domain-Driven Design (DDD)
        //and helps to create modular, testable, and maintainable systems.

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var stocks = await _stockRepo.GetAllAsync(query);
            var stocksDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocks);


        }

        // This is the method getall before the filtering modifications. 

        //[HttpGet] 
        //  public async Task<IActionResult> GetAll()
        // {
        //  if (!ModelState.IsValid) //data validation (For performing data validation)
        // return BadRequest(ModelState); //data validation (For perfoming data validation) 

        // var stocks = await _stockRepo.GetAllAsync();
        // return Ok(stocks);


        //  }

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
