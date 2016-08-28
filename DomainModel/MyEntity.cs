using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [DataContract]
    public class MyEntity : IEntityBase, IMyEntity
    {
        public MyEntity()
        {
            Identifier = "Hello";
            Name = "From";
            Description = "MyEntity";
            State = State.Unchanged;
        }
        [DataMember]
        [Key]
        public string Identifier { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public State State { get; set; }

    }
}
