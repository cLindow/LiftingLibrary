using System.Collections.Generic;

namespace LiftingLibrary.models
{
    public class Difficulty : BaseModel<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Exercise> Exercises { get; set; }
    }
}