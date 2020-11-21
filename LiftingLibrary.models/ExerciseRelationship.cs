namespace LiftingLibrary.models
{
    public class ExerciseRelationship
    {
        public string PrerequisiteId { get; set; }
        public Exercise Prerequisite { get; set; }
        public string ProgressionId { get; set; }
        public Exercise Progression { get; set; }
    }
}