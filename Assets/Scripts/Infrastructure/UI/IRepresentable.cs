using UnityEngine;

public interface IRepresentable
{
    public string Name { get; }
    public IRepresentation Representation { get; set; }
}
