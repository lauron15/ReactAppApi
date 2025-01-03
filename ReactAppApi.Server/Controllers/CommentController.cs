﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReactAppApi.Server.DTOs.Comments;
using ReactAppApi.Server.Extensions;
using ReactAppApi.Server.Interfaces;
using ReactAppApi.Server.Mappers.CommentMappers;
using ReactAppApi.Server.Models;


namespace ReactAppApi.Server.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() //fir a coding without the filtering thing, just take sure to make as this one. 
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var commentModel = await _commentRepo.GetAllAsync();
            var commentDto = commentModel.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            if (!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");

            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var commentModel = commentDto.ToCommentFromCreat(stockId);

            commentModel.AppUserId = appUser.Id;

            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());


        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdatet());
            if (comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());

        }


        [HttpDelete("{id:int}")]
        //("{id:int}")] validation, attributes must be strictly integers.
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) //data validation (For performing data validation)
                return BadRequest(ModelState); //data validation (For perfoming data validation) 

            var comment = await _commentRepo.DeleteByIdAsync(id);
            if (comment == null)
            {
                return BadRequest("Comment not found");
            }

            return NoContent();
        }





    }
}
