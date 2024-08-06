namespace Pri.PE_Milan_Cheraft.Core.Entities
{
    public class Workout : BaseEntity
    {
        public string Description { get; set; }
        public int Duration { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public int MuscleGroupId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
