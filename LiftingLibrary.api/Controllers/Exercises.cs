using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LiftingLibrary.api.Models;

namespace LiftingLibrary.api.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class Exercises : ControllerBase
    {
        private readonly ExerciseStore _store;

        public Exercises(ExerciseStore store)
        {
            _store = store;
        }

        // /api/tricks
        [HttpGet]
        public IActionResult All() => Ok(_store.All);

        // /api/tricks/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_store.All.FirstOrDefault(x => x.Id.Equals(id)));

        // /api/tricks/{id}/submissions
        // [HttpGet("{id}")]
        // public IActionResult GetSub(int id) => Ok(_store.All.FirstOrDefault(x => x.Id.Equals(id)));

        // /api/tricks
        [HttpPost]
        public IActionResult Create([FromBody] Exercise exercise)
        {
            _store.Add(exercise);
            return Ok();
        }

        // /api/tricks
        [HttpPut]
        public IActionResult Update([FromBody] Exercise exercise)
        {
            throw new NotImplementedException();
        }

        // /api/tricks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
} 