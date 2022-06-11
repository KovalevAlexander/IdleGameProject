using UnityEngine;

[CreateAssetMenu(menuName = "Game/UI/Representation Color Data")]
public class RepresentationColorData : ScriptableObject
{
    [SerializeField] private Color defaultCollor;
    [SerializeField] private Color activatedColor;
    [SerializeField] private Color disabledColor;

    public Color DefaultColor => defaultCollor;
    public Color ActivatedColor => activatedColor;
    public Color DisabledColor => disabledColor;
}
