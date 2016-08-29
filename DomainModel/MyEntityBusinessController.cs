using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MyEntityBusinessController : IBusinessController<MyEntity>
    {
        private DefaultBusinessController<MyEntity> defaultController;
        public MyEntityBusinessController()
        {
            defaultController = new DefaultBusinessController<MyEntity>();
        }
        public MyEntity Get(long id)
        {
            return defaultController.Get(id);
        }

        public List<MyEntity> GetAll()
        {
            //return defaultController.GetAll();
            using (var db = new EntityModel())
            {

                DbSet<MyEntity> set = (DbSet<MyEntity>)db.FindMyDBSet(typeof(MyEntity));
                return set.Include( e => e.Subby).ToList();
            }
        }

        public List<MyEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords)
        {
            return defaultController.GetAll(pageSize,currentPageIndex,ref totalRecords);
        }

        public List<MyEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords, string whereClause, string orderBy)
        {
            return defaultController.GetAll(pageSize, currentPageIndex, ref totalRecords, whereClause,orderBy);
        }

        public MyEntity Insert(MyEntity entity)
        {
            return defaultController.Insert(entity);
        }
    }
}
