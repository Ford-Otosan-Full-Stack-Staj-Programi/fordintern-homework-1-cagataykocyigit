using Homework1.Data.Model;
using Homework1.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<Staff> StaffRepository { get; }

        List<Staff> GetByFilter(String city , String name);
       

        
        void Complete();
    }
}
