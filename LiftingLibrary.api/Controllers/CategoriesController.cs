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
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public CategoriesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // /api/tricks
        [HttpGet]
        public IEnumerable<Category> All() => _ctx.Categories.ToList();
        
        [HttpGet("{id}")]
        public Category Get(string id) => 
            _ctx.Categories.
                FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

        [HttpGet("{id}/exercises")]
        public IEnumerable<Exercise> ListExercisesInCategory(string id) =>
            _ctx.ExerciseCategories
                .Include(x => x.Exercise)
                .Where(x => x.CategoryId.Equals(id))
                .Select(x => x.Exercise)
                .ToList();

        [HttpPost]
        public async Task<Category> Create([FromBody] Category category)
        {
            category.Id = category.Name.Replace(" ", "-").ToLowerInvariant();
            _ctx.Add(category);
            await _ctx.SaveChangesAsync();
            return category;
        }

    }
} 