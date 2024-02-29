using System;
using System.Collections.Generic;

namespace Db_employee_salary.Models;

public partial class TblEmployeeSalary
{
    public int Id { get; set; }

    public int Salary { get; set; }

    public int? PerformanceBonus { get; set; }

    public int? Incentive { get; set; }
}
