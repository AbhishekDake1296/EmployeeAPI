using Employee.Data.Interface;
using Employee.Data.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class RepositoryEmployee : IRepository<TblEmpInfo>
    {
        empdbContext _dbContext;
        public RepositoryEmployee(empdbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<TblEmpInfo> Create(TblEmpInfo _object)
        {
            var obj = await _dbContext.TblEmpInfos.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(TblEmpInfo _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TblEmpInfo> GetAll()
        {
            try
            {
                return _dbContext.TblEmpInfos.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public TblEmpInfo GetById(int Id)
        {
            return _dbContext.TblEmpInfos.Where(x => x.EmpId == Id).FirstOrDefault();
        }

        public void Update(TblEmpInfo _object)
        {
            _dbContext.TblEmpInfos.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
