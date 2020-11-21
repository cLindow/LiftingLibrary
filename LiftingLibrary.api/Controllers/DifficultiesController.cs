using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftingLibrary.data;
using LiftingLibrary.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiftingLibrary.api.Controllers
{
    [ApiController]
    [Route("api/difficulties")]
    public class DifficultiesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public DifficultiesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // /api/tricks
        [HttpGet]
        public IEnumerable<Difficulty> All() => _ctx.Difficulties.ToList();
        
        [HttpGet("{id}")]
        public Difficulty Get(string id) => 
            _ctx.Difficulties.
                FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

        [HttpGet("{id}/exercises")]
        public IEnumerable<Exercise> ListExercisesInDifficulty(string id) =>
            _ctx.Exercises
                .Where(x => x.Difficulty.Equals(id))
                .ToList();

        [HttpPost]
        public async Task<Difficulty> Create([FromBody] Difficulty difficulty)
        {
            difficulty.Id = difficulty.Name.Replace(" ", "-").ToLowerInvariant();
            _ctx.Add(difficulty);
            await _ctx.SaveChangesAsync();
            return difficulty;
        }

    }
} 