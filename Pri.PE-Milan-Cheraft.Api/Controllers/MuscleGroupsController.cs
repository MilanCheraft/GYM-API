using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.PE_Milan_Cheraft.Api.Dtos.MuscleGroups;
using Pri.PE_Milan_Cheraft.Api.Extensions;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.MuscleGroups;

namespace Pri.PE_Milan_Cheraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupsController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _muscleGroupService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Value.MapToDto());
            }
            return Ok(result.Errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _muscleGroupService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }
        [HttpPost]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Add([FromBody] MuscleGroupCreateRequestDto muscleGroupRequestDto)
        {

            var result = await _muscleGroupService
                .CreateAsync(new MuscleGroupCreateRequestModel
                {
                    Name = muscleGroupRequestDto.Name
                });
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value
                    .MapToDto());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }
        [HttpPut]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Update([FromBody] MuscleGroupUpdateRequestDto muscleGroupRequestDto)
        {
            var result = await _muscleGroupService.UpdateAsync(
                                           new MuscleGroupUpdateRequestModel
                                           {
                                               Id = muscleGroupRequestDto.Id,
                                               Name = muscleGroupRequestDto.Name
                                           });
            if (result.IsSuccess)
            {
                return Ok(result.Value.MapToDto());
            }
            return BadRequest(result.Errors);
        }
        [HttpDelete]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _muscleGroupService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("Search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var result = await _muscleGroupService.GetMuscleGroupByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }
    }
}
