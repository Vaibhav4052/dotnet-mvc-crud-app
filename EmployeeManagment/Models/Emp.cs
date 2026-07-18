using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models;

public partial class Emp
{
    [Key]
    [Required]
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;
}
