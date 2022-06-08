using UnityEngine;

public abstract class Representation<T> : IRepresentation where T : IRepresentable
{
    protected readonly T m_Owner;
    protected readonly GameObject m_UIObject;

    public IRepresentable Owner => m_Owner;
    public GameObject UIObject => m_UIObject;

    public Representation(T representable, GameObject UIObject)
    {
        m_Owner = representable;
        m_UIObject = UIObject;

        m_Owner.Representation = this;
        m_UIObject.name = m_Owner.Name;
    }

    public abstract void UpdateRepresentation();

    public virtual void Dispose()
    {
        m_Owner.Representation = null;
        GameObject.Destroy(m_UIObject);
    }
}
