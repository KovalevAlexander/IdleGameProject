using System.Collections.Generic;

using UnityEngine;

public class Representer<T, K> where T : IRepresentable
                               where K : IRepresentation
{
    protected List<K> m_Representations = new();

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

    public virtual void Clear()
    {
        foreach (var representation in m_Representations)
            representation.Dispose();

        m_Representations.Clear();
    }

    public List<K> GetRepresentations()
    {
        return m_Representations;
    }
}
