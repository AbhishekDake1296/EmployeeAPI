using System;
using System.Collections.Generic;

namespace Employee.Data.Models.EF
{
    public partial class TblEmpInfo
    {
        public int EmpId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string? Dept { get; set; }
        public int? Salary { get; set; }
    }
}
