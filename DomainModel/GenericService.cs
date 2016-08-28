using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class GenericService<TEntity,IBussinessController> :  IEntityReadService<TEntity>, IEntityEditService<TEntity>

        where TEntity :class, IEntityBase, new()

    {
        IBusinessController<TEntity> _businessController;
        public GenericService()
        {
            _businessController = new DefaultBusinessController<TEntity>();
        }
        public GenericService(IBusinessController<TEntity> controller)
        {
            _businessController = controller;
        }


        #region Implementation of IEntityReadService<TEntity>

        public TEntity Get(long Id)
        {
            return _businessController.Get(Id);
        }



        public List<TEntity> GetAll()
        {
            try
            {
                return _businessController.GetAll().ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

        }

        public List<TEntity> GetAll(int pageSize, int currentPageIndex, ref int totalRecords)
        {
            return
                _businessController.GetAll(pageSize, currentPageIndex, ref totalRecords).ToList();
        }

        public List<TEntity> GetAll(string whereClause, string orderBy, int pageSize, int currentPageIndex, ref int totalRecords)
        {
            return
                _businessController.GetAll(pageSize, currentPageIndex, ref totalRecords, whereClause, orderBy).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            return _businessController.Insert(entity);
        }




        #endregion


    }
}
