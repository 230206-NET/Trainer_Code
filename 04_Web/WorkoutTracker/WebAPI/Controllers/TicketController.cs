using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;

    public TicketController(ILogger<TicketController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Create(TicketDTO dto)
    {
        return Ok(dto);
    }

}
