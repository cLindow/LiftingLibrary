using System.Collections.Generic;
using LiftingLibrary.api.Models;

namespace LiftingLibrary.api
{
    public class ExerciseStore
    {
        private readonly List<Exercise> _exercises;

        public ExerciseStore()
        {
            _exercises = new List<Exercise>();
        }

        public IEnumerable<Exercise> All => _exercises;

        public void Add(Exercise exercise)
        {
            exercise.Id = _exercises.Count + 1;
            _exercises.Add(exercise);
        }
    }
}