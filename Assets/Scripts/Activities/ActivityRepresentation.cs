using UnityEngine;
using UnityEngine.UI;

public class ActivityRepresentation : Representation<Activity>
{
    public ActivityRepresentation(Activity representable, GameObject UIObject, RepresentationColorData colorData) : base(representable, UIObject, colorData)
    {

        UpdateRepresentation();
    }

    public override void UpdateRepresentation()
    {
        m_Text.text = m_Owner.Name;
    }
}
