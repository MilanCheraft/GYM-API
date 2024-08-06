using Microsoft.EntityFrameworkCore;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.MuscleGroups;
using Pri.PE_Milan_Cheraft.Core.Models.Results;

namespace Pri.PE_Milan_Cheraft.Core.Services.MuscleGroups
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupService(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }

        public async Task<ResultModel<MuscleGroup>> CreateAsync(MuscleGroupCreateRequestModel muscleGroupCreateRequestModel)
        {
            var muscleGroups = _muscleGroupRepository.GetAll();
            if (await muscleGroups.AnyAsync(mg => mg.Name.ToUpper() == muscleGroupCreateRequestModel.Name.ToUpper()))
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group already exists" }
                };
            }
            var muscleGroup = new MuscleGroup
            {
                Name = muscleGroupCreateRequestModel.Name
            };
            var result = await _muscleGroupRepository.AddAsync(muscleGroup);
            if (result)
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = true,
                    Value = muscleGroup
                };
            }
            return new ResultModel<MuscleGroup>
            {
                IsSuccess = false,
                Errors = new List<string> { "Muscle group not created" }
            };
        }

        public async Task<ResultModel<MuscleGroup>> DeleteAsync(int id)
        {
            var muscleGroup = await _muscleGroupRepository.GetByIdAsync(id);
            if (muscleGroup == null)
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }
            if (await _muscleGroupRepository.DeleteAsync(muscleGroup))
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<MuscleGroup>
            {
                IsSuccess = false,
                Errors = new List<string> { "Muscle group not deleted" }
            };
        }

        public async Task<ResultModel<IEnumerable<MuscleGroup>>> GetAllAsync()
        {
            var muscleGroups = await _muscleGroupRepository.GetAllAsync();
            if (muscleGroups.Count() > 0)
            {
                return new ResultModel<IEnumerable<MuscleGroup>>
                {
                    IsSuccess = true,
                    Value = muscleGroups
                };
            }
            return new ResultModel<IEnumerable<MuscleGroup>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No muscle groups found" }
            };
        }

        public async Task<ResultModel<MuscleGroup>> GetByIdAsync(int id)
        {
            var muscleGroup = await _muscleGroupRepository.GetByIdAsync(id);
            if (muscleGroup != null)
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = true,
                    Value = muscleGroup
                };
            }
            return new ResultModel<MuscleGroup>
            {
                IsSuccess = false,
                Errors = new List<string> { "Muscle group not found" }
            };
        }

        public async Task<ResultModel<IEnumerable<MuscleGroup>>> GetMuscleGroupByNameAsync(string name)
        {
            var muscleGroups = await _muscleGroupRepository.GetMuscleGroupByNameAsync(name);
            if (muscleGroups.Count() > 0)
            {
                return new ResultModel<IEnumerable<MuscleGroup>>
                {
                    IsSuccess = true,
                    Value = muscleGroups
                };
            }
            return new ResultModel<IEnumerable<MuscleGroup>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No muscle groups found" }
            };
        }

        public async Task<ResultModel<MuscleGroup>> UpdateAsync(MuscleGroupUpdateRequestModel muscleGroupUpdateRequestModel)
        {
            var muscleGroups = _muscleGroupRepository.GetAll();
            if (await muscleGroups.AnyAsync(mg => mg.Name.ToUpper() == muscleGroupUpdateRequestModel.Name.ToUpper()))
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group already exists" }
                };
            }
            var muscleGroup = await _muscleGroupRepository.GetByIdAsync(muscleGroupUpdateRequestModel.Id);
            if (muscleGroup == null)
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }
            muscleGroup.Name = muscleGroupUpdateRequestModel.Name;
            if (await _muscleGroupRepository.UpdateAsync(muscleGroup))
            {
                return new ResultModel<MuscleGroup>
                {
                    IsSuccess = true,
                    Value = muscleGroup
                };
            }
            return new ResultModel<MuscleGroup>
            {
                IsSuccess = false,
                Errors = new List<string> { "Muscle group not updated" }
            };
        }
    }
}
