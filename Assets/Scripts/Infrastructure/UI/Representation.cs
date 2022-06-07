using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Representation<T> : IRepresentation where T : IRepresentable
{
    protected RepresentationColorData m_ColorData;
    protected Button m_Button;
    protected TMP_Text m_Text;
    protected string m_TextFormat = "{0}";
    protected readonly T m_Owner;

    public Action<T> onClicked;

    public IRepresentable Owner => m_Owner;

    public Representation(T representable, GameObject UIObject, RepresentationColorData colorData)
    {
        UIObject.name = representable.Name;

        m_Owner = representable;

        m_Button = UIObject.GetComponent<Button>();
        m_Text = UIObject.GetComponentInChildren<TMP_Text>();

        m_ColorData = colorData;

        Initialize();
    }
    private void HandleClick()
    {
        onClicked?.Invoke(m_Owner);
    }

    private void Initialize()
    {
        if (m_Button is not null)
        {
            m_Button.onClick.AddListener(HandleClick);
        }
    }

    public abstract void UpdateRepresentation();
}
