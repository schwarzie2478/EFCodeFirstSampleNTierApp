using System.Collections.Generic;

namespace DomainModel
{
    public interface IBusinessController<TEntity> where TEntity : class, IEntityBase, new()
    {
        TEntity Get(long id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords);
        List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords, string whereClause, string orderBy);
        TEntity Insert(TEntity entity);
    }
}