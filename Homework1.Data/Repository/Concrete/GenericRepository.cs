using Homework1.Data.Context;
using Homework1.Data.Model;
using Homework1.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data.Repository.Concrete;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

    private readonly AppDbContext _appDbContext;    
    private DbSet<TEntity> data;
    private List<Staff> list;

    public GenericRepository(AppDbContext _appDbContext)
    {
        this._appDbContext = _appDbContext;
        this.data = this._appDbContext.Set<TEntity>();
        
    }

    //Delete
    public void Delete(TEntity entity)
    {
        data.Remove(entity);
    }

   

    //GetAll
    public List<TEntity> GetAll()
    {
        return data.ToList();
    }

    public List<TEntity> GetByFilter(TEntity entity)
    {
        throw new NotImplementedException();
    }

    //GetByID
    public TEntity GetById(int id)
    {
        return data.Find(id);
    }

    //Insert
    public void Post(TEntity entity)
    {
        data.Add(entity);
    }

    //Update
    public void Put(TEntity entity)
    {
        data.Update(entity);
        
    }

     



    

   

}
