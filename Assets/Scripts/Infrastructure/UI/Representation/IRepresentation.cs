using System;

using UnityEngine;

public interface IRepresentation : IDisposable
{
    public IRepresentable Owner { get; }
    public GameObject UIObject { get; }
}
