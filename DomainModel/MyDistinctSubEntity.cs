using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [DataContract]
    public class MyDistinctSubEntity : ISubEntity, IEntityBase
    {

        [DataMember]
        [Key]
        public string Identifier { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public State State { get; set; }


    }
}
