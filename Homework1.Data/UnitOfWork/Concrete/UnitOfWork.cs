using Homework1.Data.Context;
using Homework1.Data.Model;
using Homework1.Data.Repository.Abstract;
using Homework1.Data.Repository.Concrete;
using Homework1.Data.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data.UnitOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{


    private readonly AppDbContext data;
    private bool disposed;

    public IGenericRepository<Staff> StaffRepository { get; private set; }

    public UnitOfWork(AppDbContext data)
    {
        this.data = data;

        StaffRepository = new GenericRepository<Staff>(data);

    }
  

    public void CompleteWithTransaction()
    {
        using (var dbContextTransaction = data.Database.BeginTransaction())
        {
            try
            {
                data.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging                    
                dbContextTransaction.Rollback();
            }
        }
    }

    public void Complete()
    {
        data.SaveChanges();
    }

    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                data.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }


    // WHERE clause u burda kullandım.
    public List<Staff> GetByFilter(String city , String name )
    {
        List<Staff> staffs = StaffRepository.GetAll();

        var filteredList = staffs.Where(staff => staff.City.Equals(city) && staff.FirstName.Equals(name)).ToList();
        

        return (List<Staff>)filteredList;
    }
}
