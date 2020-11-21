using System;
using System.Linq;
using System.Linq.Expressions;
using LiftingLibrary.models;

namespace LiftingLibrary.api.ViewModels
{
    public class ExerciseViewModels
    {
        public static Expression<Func<Exercise, object>> Default =>
            exercise => new
            {
                exercise.Id,
                exercise.Name,
                exercise.Description,
                exercise.Difficulty,
                Categories = exercise.ExerciseCategories.Select(x => x.CategoryId),
                Prerequisites = exercise.Prerequisites.Select(x => x.PrerequisiteId),
                Progressions = exercise.Progressions.Select(x => x.ProgressionId)
            };
    }
}