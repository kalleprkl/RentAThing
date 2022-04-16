using System.Collections.Generic;
namespace RentAThing.Models;

public class Customer
{
    public int Id { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}