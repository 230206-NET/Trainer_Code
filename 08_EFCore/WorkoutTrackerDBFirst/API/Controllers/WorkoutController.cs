using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using DataAccess;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly Repository _repo;
        public WorkoutController(Repository repo) {
            _repo = repo;
        }
        [HttpGet]
        public List<WorkoutSession> GetAll(DateTime? date) {
            if(date != null) {
                return _repo.GetAllWorkouts((DateTime)date);
            }
            return _repo.GetAllWorkouts();
        } 
    }
}