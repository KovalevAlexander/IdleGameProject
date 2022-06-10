using System;

using UnityEngine;
using UnityEngine.UI;

public abstract class ClickableRepresentation<T> : TextRepresentation<T> where T : IRepresentable
{
    public Action<T> onClicked;

    protected Button m_Button;

    public ClickableRepresentation(T representable, GameObject UIObject, string textFormat) : base(representable, UIObject, textFormat)
    {
        m_Button = UIObject.GetComponent<Button>();
        m_Button.image.color = Owner.ColorData.DefaultColor;

#if UNITY_EDITOR
        if (m_Button == null)
            Debug.LogError($"Please ensure that the prefab for {representable.Name} has a button component", UIObject);
#endif

        m_Button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        onClicked?.Invoke(m_Owner);
    }

    public override void Dispose()
    {
        base.Dispose();

        m_Button.onClick.RemoveAllListeners();
        m_Button = null;
    }

}
