using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ResourceRepresentationSlider : MonoBehaviour
{
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text counter;
    [SerializeField] Slider slider;
    [SerializeField] Image sliderFillImage;

    public TMP_Text Header => header;
    public TMP_Text Counter => counter;
    public Slider Slider => slider;
    public Image Image => sliderFillImage;
}
