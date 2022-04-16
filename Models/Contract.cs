using System.Collections.Generic;
namespace RentAThing.Models;

public class Contract
{
    public int Id { get; set; }

    public Thing Thing { get; set; }
}