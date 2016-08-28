using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public enum State
    {
        [EnumMember]
        Added,
        [EnumMember]
        Unchanged,
        [EnumMember]
        Modified,
        [EnumMember]
        Deleted
    }
}