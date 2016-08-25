namespace DomainModel
{
    using System;
    using System.Data.Entity;
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
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}