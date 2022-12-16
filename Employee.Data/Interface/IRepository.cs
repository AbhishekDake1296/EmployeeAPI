using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Interface
{
    public interface IRepository<TblEmpInfo>
    {
        public Task<TblEmpInfo> Create(TblEmpInfo _employee);

        public void Update(TblEmpInfo _employee);

        public IEnumerable<TblEmpInfo> GetAll();

        public TblEmpInfo GetById(int Id);

        public void Delete(TblEmpInfo _employee);
    }
}
