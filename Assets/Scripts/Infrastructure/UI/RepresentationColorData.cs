using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Game/UI/Representation Color Data")]
public class RepresentationColorData : ScriptableObject
{
    [SerializeField] private ColorBlock colors;
    [SerializeField] private Color defaultCollor;
    [SerializeField] private Color activatedColor;
    [SerializeField] private Color disabledColor;

    public ColorBlock Colors => colors;
    public Color DefaultColor => defaultCollor;
    public Color ActivatedColor => activatedColor;
    public Color DisabledColor => disabledColor;
}
