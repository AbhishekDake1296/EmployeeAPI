using Employee.Data.Interface;
using Employee.Data.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.EmpService
{
    public class EmployeeService : IEmployeeService<TblEmpInfo>
    {
        private readonly IRepository<TblEmpInfo> _employee;

        public EmployeeService(IRepository<TblEmpInfo> employee)
        {
            _employee = employee;
        }
        //Get Person Details By employee Id  
        public TblEmpInfo GetEmployeeById(int empId)
        {
            return _employee.GetById(empId);
        }
        //GET All employee Details   
        public IEnumerable<TblEmpInfo> GetAllEmployee()
        {
            try
            {
                return _employee.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Add employee  
        public async Task<TblEmpInfo> AddEmployee(TblEmpInfo employee)
        {
            return await _employee.Create(employee);
        }
        public void UpdateEmployee(TblEmpInfo employee)
        {
            try
            {
                var DataList = _employee.GetAll().Where(x => x.EmpId == employee.EmpId).ToList();
                foreach (var item in DataList)
                {
                    _employee.Update(item);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteEmployee(int empId)
        {
            try
            {
                var DataList = _employee.GetAll().Where(x => x.EmpId == empId).ToList();
                foreach (var item in DataList)
                {
                    _employee.Delete(item);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
