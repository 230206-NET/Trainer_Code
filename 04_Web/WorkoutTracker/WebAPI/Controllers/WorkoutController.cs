using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly ILogger<WorkoutController> _logger;
    private readonly WorkoutService _service;

    public WorkoutController(ILogger<WorkoutController> logger, WorkoutService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public List<WorkoutSession> Get()
    {
        return _service.GetAllWorkouts();
    }

    [HttpPost]
    public ActionResult<WorkoutSession> Create(WorkoutSession sessionToCreate)
    {
        return Created("/workouts", _service.CreateNewSession(sessionToCreate));
    }

    [HttpPut]
    public ActionResult Put(WorkoutSession sessionToModify) {
        return Ok();
    }
}
