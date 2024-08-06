namespace Pri.PE_Milan_Cheraft.Core.Models.Workouts
{
    public class WorkoutCreateRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int MuscleGroupsId { get; set; }
        public IEnumerable<int> ExerciseIds { get; set; }
        public int Duration { get; set; }
    }
}
