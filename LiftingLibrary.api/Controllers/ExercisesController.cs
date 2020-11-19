using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Exercise> All() => _ctx.Exercises.ToList();
        
        [HttpGet("{id}")]
        public Exercise Get(int id) => _ctx.Exercises.FirstOrDefault(x => x.Id.Equals(id));
        
        [HttpGet("{exerciseId}/submissions")]
        public IEnumerable<Submission> ListSubmissionsForTrick(int exerciseId) =>
            _ctx.Submissions.Where(x => x.ExerciseId.Equals(exerciseId)).ToList();
        
        [HttpPost]
        public async Task<Exercise> Create([FromBody] Exercise exercise)
        {
            _ctx.Add(exercise);
            await _ctx.SaveChangesAsync();
            return exercise;
        }
        
        [HttpPut]
        public async Task<Exercise> Update([FromBody] Exercise exercise)
        {
            if (exercise.Id == 0)
            {
                return null;
            }

            _ctx.Add(exercise);
            await _ctx.SaveChangesAsync();
            return exercise;
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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