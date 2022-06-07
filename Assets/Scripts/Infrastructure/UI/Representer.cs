using System.Collections.Generic;
using UnityEngine;

public abstract class Representer<T> : Singleton<Representer<T>> where T : IRepresentable 
{
    [Header("UI")]
    [SerializeField] [Tooltip("Optional!")] protected Transform UIRoot;
    [SerializeField] protected GameObject UIPrefab;
    [SerializeField] protected RepresentationColorData colorData;

    protected List<IRepresentation> m_Representations = new();

    protected abstract void CreateRepresentations();

    protected void RemoveRepresentations()
    {
        m_Representations.Clear();
    }
}
