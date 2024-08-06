using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.PE_Milan_Cheraft.Api.Dtos.Workouts;
using Pri.PE_Milan_Cheraft.Api.Extensions;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Workouts;

namespace Pri.PE_Milan_Cheraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Client")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workouts = await _workoutService.GetAllAsync();
            if (!workouts.IsSuccess)
            {
                return Ok(workouts.Errors);
            }
            return Ok(workouts.Value.MapToDto());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var workout = await _workoutService.GetByIdAsync(id);
            if (!workout.IsSuccess)
            {
                return NotFound(workout.Errors);
            }
            return Ok(workout.Value.MapToDto());
        }
        [HttpGet("Search/ByUser/{id}")]
        public async Task<IActionResult> SearchByUser(string id)
        {
            var workouts = await _workoutService.GetWorkoutsByUserIdAsync(id);
            if (!workouts.IsSuccess)
            {
                return Ok(workouts.Errors);
            }
            return Ok(workouts.Value.MapToDto());
        }
        [HttpGet("Search/ByMuscleGroup/{id}")]
        public async Task<IActionResult> SearchByMuscleGroup(int id)
        {
            var workouts = await _workoutService.GetWorkoutsByMuscleGroupIdAsync(id);
            if (!workouts.IsSuccess)
            {
                return Ok(workouts.Errors);
            }
            return Ok(workouts.Value.MapToDto());
        }
        [HttpPost]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Add([FromBody] WorkoutCreateRequestDto workoutCreateRequestDto)
        {
            var result = await _workoutService.CreateAsync(new WorkoutCreateRequestModel
            {
                Name = workoutCreateRequestDto.Name,
                Description = workoutCreateRequestDto.Description,
                UserId = workoutCreateRequestDto.UserId,
                Duration = workoutCreateRequestDto.Duration,
                ExerciseIds = workoutCreateRequestDto.ExerciseIds,
                MuscleGroupsId = workoutCreateRequestDto.MuscleGroupId
            });
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value.MapToDto());
        }
        [HttpPut]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Update([FromBody] WorkoutUpdateRequestDto workoutUpdateRequestDto)
        {
            var result = await _workoutService.UpdateAsync(new WorkoutUpdateRequestModel
            {
                Id = workoutUpdateRequestDto.Id,
                Name = workoutUpdateRequestDto.Name,
                Description = workoutUpdateRequestDto.Description,
                Duration = workoutUpdateRequestDto.Duration,
                ExerciseIds = workoutUpdateRequestDto.ExerciseIds,
                MuscleGroupsId = workoutUpdateRequestDto.MuscleGroupId,
                UserId = workoutUpdateRequestDto.UserId
            });
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Value.MapToDto());
        }
        [HttpDelete]
        [Authorize(Policy = "Trainer")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _workoutService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        [HttpGet("Search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var workouts = await _workoutService.GetWorkoutByNameAsync(name);
            if (!workouts.IsSuccess)
            {
                return Ok(workouts.Errors);
            }
            return Ok(workouts.Value.MapToDto());
        }
    }
}
