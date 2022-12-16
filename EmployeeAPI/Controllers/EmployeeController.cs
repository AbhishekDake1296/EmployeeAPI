using Employee.Business.EmpService;
using Employee.Data.Interface;
using Employee.Data.Models.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService<TblEmpInfo> _Employee;

        public EmployeeController(IEmployeeService<TblEmpInfo> Employee)
        {
            _Employee = Employee;
        }
        //Add Employee  
        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] TblEmpInfo employee)
        {
            try
            {
                await _Employee.AddEmployee(employee);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Employee  
        [HttpDelete("DeleteEmployee")]
        public bool DeleteEmployee(int empId)
        {
            try
            {
                _Employee.DeleteEmployee(empId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Employee  
        [HttpPut("UpdateEmployee")]
        public bool UpdateEmployee(int id, TblEmpInfo tblEmpInfo)
        {
            try
            {
                var tableData = _Employee.GetEmployeeById(id);
                if (tableData != null)
                {
                    tableData.Name = tblEmpInfo.Name;
                    tableData.Mobile = tblEmpInfo.Mobile;
                    tableData.EmailId = tblEmpInfo.EmailId;
                    tableData.Address = tblEmpInfo.Address;
                    tableData.Dept = tblEmpInfo.Dept;
                    tableData.Salary = tblEmpInfo.Salary;
                }

                if (tableData != null)
                {
                    _Employee.UpdateEmployee(tableData);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //GET All Person  
        [HttpGet("GetAllEmployee")]
        public IEnumerable<TblEmpInfo> GetAllEmployee()
        {
            var data = _Employee.GetAllEmployee();
            return data;
        }
    }
}
