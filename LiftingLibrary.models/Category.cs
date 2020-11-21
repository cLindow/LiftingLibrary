using System.Collections.Generic;

namespace LiftingLibrary.models
{
    public class Category : BaseModel<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ExerciseCategory> Exercises { get; set; }
    }
}