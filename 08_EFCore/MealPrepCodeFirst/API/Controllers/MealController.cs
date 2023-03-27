using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        private readonly Repository _repo;
        public MealController(Repository repo) {
            _repo = repo;
        }

        [HttpPost]
        public List<Meal> Create(Meal m) {
            _repo.CreateMeal(m);
            return _repo.GetAll();
        }

        [HttpGet]
        public List<Meal> GetAll() {
            return _repo.GetAll();
        }
        [HttpPut]
        public Meal Update(Meal m) {
            return _repo.UpdateMeal(m);
        }
        [HttpDelete]
        public Meal Delete(Meal m) {
            return _repo.DeleteMeal(m);
        }
    }
}