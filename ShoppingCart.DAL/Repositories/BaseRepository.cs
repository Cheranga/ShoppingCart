using System;
using System.Data.Entity;
using System.Linq;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T:class
    {
        #region Properties

        public DbContext Context { get; set; }
        public DbSet<T> DbSet { get; set; }

        #endregion

        #region Constructor

        public BaseRepository(DbContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        #endregion

        #region IRepository Implementation
        
        public IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            //
            // TODO
            //
        }

        public void Update(T entity)
        {
            //
            // TODO
            //
        }

        public void Delete(T entity)
        {
            //
            // TODO
            //
        }

        public void Delete(int id)
        {
            //
            // TODO
            //
        }

        #endregion
    }
}
