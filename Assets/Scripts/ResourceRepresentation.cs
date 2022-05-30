using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ResourceRepresentation : MonoBehaviour
{
    [SerializeField] private TMP_Text resourceText;
    [SerializeField] private Slider resourceSlider;

    private float _Current;
    private float _Max;

    public void UpdateRepresentation(float value)
    {
        _Current = value;

        resourceText.text = $"{value.ToString("0.00")}/{_Max.ToString("0.00")}";
        resourceSlider.value = value;
    }

    public void UpdateValueBounds(float max)
    {
        _Max = max;

        resourceSlider.maxValue = _Max;

        UpdateRepresentation(_Current);
    }

}
