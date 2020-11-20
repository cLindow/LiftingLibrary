namespace LiftingLibrary.models
{
    public class Submission : BaseModel<int>
    {
        public string ExerciseId { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
    }
}