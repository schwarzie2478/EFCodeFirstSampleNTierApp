using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [ServiceContract (Namespace = "ArcelorMittal.Generic.Testing.EntityReadService")]
    public interface IEntityReadService<TEntity>
            where TEntity : IEntityBase, new()
    {
        [OperationContract(Name = "Get")]
        TEntity Get(Int64 Id);
        [OperationContract(Name = "GetAll")]
        List<TEntity> GetAll();
        [OperationContract(Name = "GetAllPaged")]
        List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords);
        [OperationContract(Name = "GetAllConditional")]
        List<TEntity> GetAll(string whereClause, string orderBy, int pageSize, int currentPageIndex, ref int totalRecords);

    }
    [ServiceContract(Namespace = "ArcelorMittal.Generic.Testing.EntityEditService")]
    public interface IEntityEditService<TEntity>   where TEntity : IEntityBase, new()
    {
        [OperationContract(Name = "Get")]
        TEntity Get(Int64 Id);
        [OperationContract(Name = "GetAll")]
        List<TEntity> GetAll();
        [OperationContract(Name = "GetAllPaged")]
        List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords);
        [OperationContract(Name = "GetAllConditional")]
        List<TEntity> GetAll(string whereClause, string orderBy, int pageSize, int currentPageIndex, ref int totalRecords);
        [OperationContract(Name = "Insert")]
        TEntity Insert(TEntity entity);
    }
}
