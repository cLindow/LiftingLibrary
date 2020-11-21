using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftingLibrary.data;
using LiftingLibrary.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LiftingLibrary.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

                if (env.IsDevelopment())
                {
                    // Difficulties
                    ctx.Add(new Difficulty {Id = "easy", Name = "Easy", Description = "easy Test"});
                    ctx.Add(new Difficulty {Id = "medium", Name = "Medium", Description = "medium Test"});
                    ctx.Add(new Difficulty {Id = "hard", Name = "Hard", Description = "hard Test"});
                    ctx.Add(new Category {Id = "squat", Name = "Squat", Description = "bend your knees Test"});
                    ctx.Add(new Category {Id = "bench", Name = "Bench", Description = "touch your chestTest"});
                    ctx.Add(new Category {Id = "lunge", Name = "Lunge", Description = "take a step Test"});
                    ctx.Add(new Exercise
                    {
                        Id = "over-head-squat",
                        Name = "Over head squat",
                        Description = "TEST: Bend your knees with weight above head",
                        Difficulty = "hard",
                        ExerciseCategories = new List<ExerciseCategory>
                        {
                            new ExerciseCategory {CategoryId = "squat"}
                        }
                    });
                    ctx.Add(new Exercise
                    {
                        Id = "front-squat",
                        Name = "Front squat",
                        Difficulty = "medium",
                        Description = "TEST: Bend your knees with weight on top of your shoulders",
                        ExerciseCategories = new List<ExerciseCategory>
                        {
                            new ExerciseCategory {CategoryId = "squat"}
                        },
                        Progressions = new List<ExerciseRelationship>
                        {
                            new ExerciseRelationship { ProgressionId = "over-head-squat"}
                        }
                    });
                    ctx.SaveChanges();
                }
            }
                
                
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}