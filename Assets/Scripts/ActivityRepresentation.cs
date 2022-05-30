using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityRepresentation : MonoBehaviour
{
    [SerializeField] private Button Button;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color activeColor = Color.red;

    public void UpdateWithNormalColor()
    {
        UpdateRepresentation(normalColor);
    }

    public void UpdateWithActiveColor()
    {
        UpdateRepresentation(activeColor);
    }

    private void UpdateRepresentation(Color color)
    {
        Button.image.color = color;
    }
}
