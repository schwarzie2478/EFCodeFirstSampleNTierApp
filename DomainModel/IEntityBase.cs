using System.Runtime.Serialization;

namespace DomainModel
{


    public interface IEntityBase
    {
        State State { get; set; }
    }
}