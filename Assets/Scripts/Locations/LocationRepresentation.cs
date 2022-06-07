using UnityEngine;

public class LocationRepresentation : Representation<Location>
{
    public LocationRepresentation(Location representable, GameObject UIObject, RepresentationColorData colorData) : base(representable, UIObject, colorData)
    {
        UpdateRepresentation();
    }

    public override void UpdateRepresentation()
    {
        m_Text.text = string.Format(m_TextFormat, m_Owner.Name);
    }
}
