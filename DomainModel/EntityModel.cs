namespace DomainModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class EntityModel : DbContext
    {
        // Your context has been configured to use a 'EntityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DomainModel.EntityModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EntityModel' 
        // connection string in the application configuration file.
        public EntityModel()
            : base("name=EntityModel")
        {
            ((IObjectContextAdapter)this).ObjectContext
                 .ObjectMaterialized += (sender, args) =>
                 {
                     var entity = args.Entity as IEntityBase;
                     if (entity != null)
                     {
                         entity.State = State.Unchanged;
                     }
                 };
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<YourEntity> YourEntities { get; set; }

        public object FindMyDBSet(Type type) 
        {
            if (type.Equals(typeof(MyEntity)))
            {
                return MyEntities;
            }
            if (type.Equals(typeof(YourEntity)))
            {
                return YourEntities;
            }
            return null;
        }

        private static void ApplyChanges<TEntity>(TEntity root)
         where TEntity : class, IEntityBase
        {
            using (var context = new EntityModel())
            {
                context.Set<TEntity>().Add(root);

                CheckForEntitiesWithoutStateInterface(context);

                foreach (var entry in context.ChangeTracker
                .Entries<IEntityBase>())
                {
                    IEntityBase stateInfo = entry.Entity;
                    entry.State = ConvertState(stateInfo.State);
                }
                context.SaveChanges();
            }
        }
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        private static void CheckForEntitiesWithoutStateInterface(EntityModel context)
        {
            var entitiesWithoutState =
            from e in context.ChangeTracker.Entries()
            where !(e.Entity is IEntityBase)
            select e;

            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException("All entities must implement IEntityBase");
            }
        }
    }


}