using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs;

public class User {
    public int Id {get; set; }
    public string userName { get; set; }
}
public class Ticket{
    public int Id { get; set; }
    public string Description { get; set; }

    [Range(0, 10000)]
    public decimal Amount { get; set; }
}

public class TicketDTO {
    public User user { get; set; }
    public Ticket ticketToCreate { get; set; }
}