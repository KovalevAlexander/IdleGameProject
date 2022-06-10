using System.Text;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public sealed class ResourceRepresentation : TextRepresentation<Resource>
{
    private readonly StringBuilder m_SB = new();
    private readonly Slider m_Slider;

    private readonly TMP_Text m_Header;
    private readonly TMP_Text m_Counter;

    private float m_Current;
    private float m_Max;

    public ResourceRepresentation(Resource representable, GameObject uiObject, string textFormat) : base(representable, uiObject, textFormat)
    {
        m_TextFormat = "{0:0.##} / {1:0.##}";

        var refs = uiObject.GetComponent<ResourceRepresentationSlider>();

        m_Header = refs.Header;
        m_Counter = refs.Counter;

        m_Header.text = representable.Name;

        m_Slider = refs.Slider;
        refs.Image.color = Owner.ColorData.DefaultColor;
 
        m_Current = representable.Value;
        m_Max = representable.Maximum;

        m_Slider.maxValue = m_Max;

        representable.onValueChanged = UpdateValue;
        representable.onMaxChanged = UpdateValueBounds;

        UpdateRepresentation();
    }

    public override void UpdateRepresentation()
    {
        m_SB.Clear();

       
        m_SB.AppendFormat(m_TextFormat, m_Current, m_Max);

        m_Counter.text = m_SB.ToString();
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
