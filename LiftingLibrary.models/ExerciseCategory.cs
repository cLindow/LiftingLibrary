namespace LiftingLibrary.models
{
    public class ExerciseCategory
    {
        public string ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}