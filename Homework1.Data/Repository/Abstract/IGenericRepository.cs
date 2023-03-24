using Homework1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class 
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Put(TEntity entity);

        void Delete(TEntity entity);

       

        void Post(TEntity entity);

       


    }
}
