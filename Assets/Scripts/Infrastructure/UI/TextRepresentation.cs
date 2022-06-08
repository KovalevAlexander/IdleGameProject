using UnityEngine;

public abstract class TextRepresentation<T> : Representation<T> where T : IRepresentable
{
    protected string m_TextFormat;

    public TextRepresentation(T representable, GameObject UIObject, string textFormat = "{0}") : base(representable, UIObject)
    {
        m_TextFormat = textFormat;
    }
}
