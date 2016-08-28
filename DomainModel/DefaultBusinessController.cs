using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{


    internal class DefaultBusinessController<TEntity> : IBusinessController<TEntity> where TEntity :class, IEntityBase, new()
    {
        public TEntity Insert(TEntity entity)
        {
            using (var db = new EntityModel())
            {
                DbSet<TEntity> set = (DbSet<TEntity>)db.FindMyDBSet(typeof(TEntity));
                var result =  set.Add(entity);
                db.SaveChanges();
                //return the same entity, no special treatement needed
                return result;
            }
        }
        public  TEntity Get(long id)
        {
            throw new NotImplementedException();
        }

        public  List<TEntity> GetAll()
        {
            using (var db = new EntityModel())
            {

                DbSet < TEntity > set = (DbSet<TEntity>)db.FindMyDBSet(typeof(TEntity));
                return set.ToList();
            }         
        }

        public  List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords)
        {
            throw new NotImplementedException();
        }

        public  List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords, string whereClause, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}