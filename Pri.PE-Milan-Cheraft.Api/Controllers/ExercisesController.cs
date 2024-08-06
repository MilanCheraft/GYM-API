using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.PE_Milan_Cheraft.Api.Dtos.Exercises;
using Pri.PE_Milan_Cheraft.Api.Extensions;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Exercises;

namespace Pri.PE_Milan_Cheraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMuscleGroupService _muscleGroupService;

        public ExercisesController(IExerciseService exerciseService, IMuscleGroupService muscleGroupService)
        {
            _exerciseService = exerciseService;
            _muscleGroupService = muscleGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseService.GetAllAsync();
            return Ok(exercises.Value.MapToDto());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            if (exercise.IsSuccess)
            {
                return Ok(exercise.Value.MapToDto());
            }
            return NotFound(exercise.Errors);
        }
        [HttpPost]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Add(ExerciseCreateRequestDto exerciseCreateRequestModel)
        {
            var result = await _exerciseService.CreateAsync(new ExerciseCreateRequestModel
            {
                Name = exerciseCreateRequestModel.Name,
                Description = exerciseCreateRequestModel.Description,
                MuscleGroupId = exerciseCreateRequestModel.MuscleGroupId,
                Reps = exerciseCreateRequestModel.Reps,
                Sets = exerciseCreateRequestModel.Sets,
                Weight = exerciseCreateRequestModel.Weight
            });
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value.MapToDto());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }
        [HttpPut]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Update([FromBody] ExerciseUpdateRequestDto exerciseUpdateRequestDto)
        {
            var result = await _exerciseService.UpdateAsync(new ExerciseUpdateRequestModel
            {
                Id = exerciseUpdateRequestDto.Id,
                Name = exerciseUpdateRequestDto.Name,
                Description = exerciseUpdateRequestDto.Description,
                MuscleGroupId = exerciseUpdateRequestDto.MuscleGroupId,
                Reps = exerciseUpdateRequestDto.Reps,
                Sets = exerciseUpdateRequestDto.Sets,
                Weight = exerciseUpdateRequestDto.Weight
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
            var result = await _exerciseService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("ByMuscleGroup/{id}")]
        public async Task<IActionResult> SearchByMuscleGroup(int id)
        {
            var result = await _exerciseService.GetExercisesByMuscleGroupIdAsync(id);
            if (!result.IsSuccess)
            {
                return Ok(result.Errors);
            }
            return Ok(result.Value.MapToDto());
        }
        [HttpGet("Search/ByMuscleGroup/{name}")]
        public async Task<IActionResult> SearchByMuscleGroup(string name)
        {
            var result = await _exerciseService.GetExercisesByMuscleGroupNameAsync(name);
            if (!result.IsSuccess)
            {
                return Ok(result.Errors);
            }
            return Ok(result.Value.MapToDto());
        }
        [HttpGet("Search/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var result = await _exerciseService.GetExercisesByNameAsync(name);
            if (!result.IsSuccess)
            {
                return Ok(result.Errors);
            }
            return Ok(result.Value.MapToDto());
        }
    }
}
