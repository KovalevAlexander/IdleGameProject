using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Representer<T, K>   where T : IRepresentable
                                        where K : IRepresentation
{
    private List<K> m_Representations = new();

    public void CreateRepresentations(T[] representables, GameObject uiPrefab, Transform[] uiRoots)
    {
        int count = 0;

        foreach (var representable in representables)
        {
            CreateRepresentation(representable, uiPrefab, uiRoots[count]);
            count += 1;
        }

    }

    public void CreateRepresentations(T[] representables, GameObject uiPrefab, Transform uiRoot)
    {
        foreach (var representable in representables)
            CreateRepresentation(representable, uiPrefab, uiRoot);
    }

    public void CreateRepresentation(T representable, GameObject uiPrefab, Transform uiRoot)
    {
        var representation = RepresentationFactory<K>.Get(representable, uiPrefab, uiRoot);
        m_Representations.Add(representation);
    }

    public void Clear()
    {
        foreach (var representation in m_Representations)
            representation.Dispose();

        m_Representations.Clear();
    }

    public List<K> GetRepresentations()
    {
        return m_Representations;
    }

    public void RemoveRepresentation(T representable)
    {
        var representationToRemove = m_Representations.Find(representation 
            => (IRepresentation)representation == representable.Representation);
        
        if (representationToRemove == null)
            return;

        representationToRemove.Dispose();

        m_Representations.Remove(representationToRemove);
    }
}
