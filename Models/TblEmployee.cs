using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db_employee_salary.Models;

public partial class TblEmployee
{
    public int EId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Ph { get; set; } = null!;

    [NotMapped]
    //[Display(Salary_clmn as salary)]
    public int Salary_clmn { get; set; }
}
