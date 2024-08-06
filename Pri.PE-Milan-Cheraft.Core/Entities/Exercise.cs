namespace Pri.PE_Milan_Cheraft.Core.Entities
{
    public class Exercise : BaseEntity
    {
        public string Description { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public int MuscleGroupId { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public double Weight { get; set; }
    }
}
