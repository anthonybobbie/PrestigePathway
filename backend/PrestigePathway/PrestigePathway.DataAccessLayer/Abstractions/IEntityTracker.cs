namespace PrestigePathway.DataAccessLayer.Abstractions;

public interface IEntityTracker
{
    DateTime? ModifiedOnUtc { get; set; }
    DateTime CreatedOnUtc { get; set; }
}