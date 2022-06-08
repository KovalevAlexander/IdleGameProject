using UnityEngine;

using TMPro;

public class LocationRepresentation : ClickableRepresentation<Location>
{
    private TMP_Text m_Text;

    public LocationRepresentation(Location representable, GameObject uiObject, string textFormat) : base(representable, uiObject, textFormat)
    {
        m_TextFormat = "{0}";

        m_Text = uiObject.GetComponentInChildren<TMP_Text>();

        UpdateRepresentation();
    }

    public override void UpdateRepresentation()
    {
        m_Text.text = string.Format(m_TextFormat, m_Owner.Name);
    }
}
