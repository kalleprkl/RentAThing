using System.ComponentModel.DataAnnotations.Schema;

namespace RentAThing.Models;

public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}