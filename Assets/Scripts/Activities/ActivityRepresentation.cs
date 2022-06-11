using UnityEngine;

using TMPro;

public sealed class ActivityRepresentation : ClickableRepresentation<Activity>
{
    private readonly TMP_Text m_Text;

    public ActivityRepresentation(Activity representable, GameObject uiObject, string textFormat) : base(representable, uiObject, textFormat)
    {
        m_TextFormat = "{0}";
        m_Text = uiObject.GetComponentInChildren<TMP_Text>();
        m_Text.text = Owner.Name;

        var colors = m_Button.colors;
        colors.pressedColor = Owner.ColorData.ActivatedColor;
        m_Button.colors = colors;

        representable.onUnavailable += Disable;
        representable.onAvailable += Enable;
        representable.onActivated += Activate;
        representable.onStopped += Enable;

        representable.Update();
    }

    private void Disable()
    {
        m_Button.image.color = Owner.ColorData.DisabledColor;
        m_Button.interactable = false;
    }

    private void Enable()
    {
        m_Button.interactable = true;
        m_Button.image.color = Owner.ColorData.DefaultColor;
    }

    private void Activate()
    {
        m_Button.interactable = true;
        m_Button.image.color = Owner.ColorData.ActivatedColor;
    }

    public override void UpdateRepresentation()
    {
        return;
    }
}
