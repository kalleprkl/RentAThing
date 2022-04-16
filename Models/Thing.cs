using System.ComponentModel.DataAnnotations.Schema;

namespace RentAThing.Models;

public class Thing
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
}
