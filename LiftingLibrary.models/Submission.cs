namespace LiftingLibrary.models
{
    public class Submission : BaseModel
    {
        public int ExerciseId { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
    }
}