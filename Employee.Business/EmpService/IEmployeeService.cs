using Employee.Data.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.EmpService
{
    public interface IEmployeeService<TblEmpInfo>
    {
        public Task<TblEmpInfo> AddEmployee(TblEmpInfo _employee);

        public void UpdateEmployee(TblEmpInfo employee);

        public IEnumerable<TblEmpInfo> GetAllEmployee();

        public TblEmpInfo GetEmployeeById(int Id);

        public void DeleteEmployee(int empId);
    }
}
