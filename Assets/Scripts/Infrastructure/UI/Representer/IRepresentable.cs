using System;

public interface IRepresentable
{
    public string Name { get; }
    public IRepresentation Representation { get; set; }

    public RepresentationColorData ColorData { get; }
}
