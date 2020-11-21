using System.Collections.Generic;

namespace LiftingLibrary.models
{
    public class Exercise : BaseModel<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public IList<ExerciseRelationship> Prerequisites { get; set; }
        public IList<ExerciseRelationship> Progressions { get; set; }
        public IList<ExerciseCategory> ExerciseCategories { get; set; }
    }
}