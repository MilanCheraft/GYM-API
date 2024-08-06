namespace Pri.PE_Milan_Cheraft.Core.Entities
{
    public class MuscleGroup : BaseEntity
    {
        //relations
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
