namespace DomainModel
{
    public interface ISubEntity
    {
        string Identifier { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}