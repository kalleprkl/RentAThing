namespace RentAThing.Models;

public class Contract
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ThingId { get; set; }

    public Customer Customer { get; set; }
    public Thing Thing { get; set; }
}