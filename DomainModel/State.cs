using System.Runtime.Serialization;

namespace DomainModel
{
    [DataContract]
    public enum State
    {
        [EnumMember]
        Unchanged,
        [EnumMember]
        Added,
        [EnumMember]
        Modified,
        [EnumMember]
        Deleted
    }
}