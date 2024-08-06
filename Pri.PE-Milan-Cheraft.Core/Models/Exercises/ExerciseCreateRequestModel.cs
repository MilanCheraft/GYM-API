namespace Pri.PE_Milan_Cheraft.Core.Models.Exercises
{
    public class ExerciseCreateRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MuscleGroupId { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public double Weight { get; set; }

    }
}
