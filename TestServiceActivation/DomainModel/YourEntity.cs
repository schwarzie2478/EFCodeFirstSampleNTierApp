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
    public class YourEntity : IEntityBase
    {
        public YourEntity()
        {
            Identifier = "GoodBye";
            Name = "From";
            Description = "YourEntity";
        }
        [DataMember]
        [Key]
        public string Identifier { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

    }

}
