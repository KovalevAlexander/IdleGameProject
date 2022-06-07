using System.Text;

using UnityEngine;
using UnityEngine.UI;

public sealed class ResourceRepresentation : Representation<Resource>
{
    private readonly StringBuilder m_SB = new();
    private readonly Slider m_Slider;
    private readonly TMPro.TMP_Text m_CounterText;

    private float m_Current;
    private float m_Max;

    public ResourceRepresentation(Resource representable, GameObject UIObject, RepresentationColorData colorData) : base(representable, UIObject, colorData)
    {
        var texts = UIObject.GetComponentsInChildren<TMPro.TMP_Text>();
        m_CounterText = texts[0];
        m_Text = texts[1];
        m_Text.text = representable.Name;

        m_TextFormat = "{0} / {1}";
        m_Slider = UIObject.GetComponentInChildren<Slider>();
        m_Slider.colors = colorData.Colors;

        m_Current = representable.Value;
        m_Max = representable.Maximum;

        representable.onValueChanged = UpdateValue;
        representable.onMaxChanged = UpdateValueBounds;

        UpdateRepresentation();
    }

    public override void UpdateRepresentation()
    {
        m_SB.Clear();
        m_SB.AppendFormat(m_TextFormat, m_Current.ToString("0.00"), m_Max.ToString("0.00"));

        m_CounterText.text = m_SB.ToString();
        m_Slider.value = m_Current;
    }

    private void UpdateValueBounds(float max)
    {
        m_Max = max;

        m_Slider.maxValue = m_Max;

        UpdateRepresentation();
    }

    private void UpdateValue(float value)
    {
        m_Current = value;

        UpdateRepresentation();
    }
}
