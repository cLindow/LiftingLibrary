using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftingLibrary.api.Form;
using LiftingLibrary.api.ViewModels;
using LiftingLibrary.data;
using LiftingLibrary.models;
using Microsoft.AspNetCore.Mvc;

namespace LiftingLibrary.api.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public ExercisesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // /api/tricks
        [HttpGet]
        public IEnumerable<object> All() => _ctx.Exercises.Select(ExerciseViewModels.Default).ToList();
        
        [HttpGet("{id}")]
        public object Get(string id) => 
            _ctx.Exercises
                .Where(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                .Select(ExerciseViewModels.Default)
                .FirstOrDefault();
        
        [HttpGet("{exerciseId}/submissions")]
        public IEnumerable<Submission> ListSubmissionsForTrick(string exerciseId) =>
            _ctx.Submissions.
                Where(x => x.ExerciseId.Equals(exerciseId, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        
        [HttpPost]
        public async Task<object> Create([FromBody] ExerciseForm exerciseForm)
        {
            Exercise exercise = new Exercise
            {
                Id = exerciseForm.Id = exerciseForm.Name.Replace(" ", "-").ToLowerInvariant(),
                Name = exerciseForm.Name,
                Description = exerciseForm.Description,
                Difficulty = exerciseForm.Difficulty,
                ExerciseCategories = exerciseForm.Categories.Select(x => new ExerciseCategory
                {
                    CategoryId = x
                }).ToList()
            };
            _ctx.Add(exercise);
            await _ctx.SaveChangesAsync();
            return ExerciseViewModels.Default.Compile().Invoke(exercise);
        }
        
        [HttpPut]
        public async Task<object> Update([FromBody] Exercise exercise)
        {
            if (string.IsNullOrEmpty(exercise.Id))
            {
                return null;
            }

            _ctx.Add(exercise);
            await _ctx.SaveChangesAsync();
            return ExerciseViewModels.Default.Compile().Invoke(exercise);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Exercise exercise = _ctx.Exercises.FirstOrDefault(x => x.Id.Equals(id));
            if (exercise == null)
            {
                return null;
            }
            exercise.Deleted = true;
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
} 