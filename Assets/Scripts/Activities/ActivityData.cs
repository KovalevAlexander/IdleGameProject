using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Activity Data")]
public sealed class ActivityData : ScriptableObject
{
    [Header("General")]
    [SerializeField] private string activityName;
    [SerializeField] private ActivityType activityType;
    [SerializeField] private bool initiallyUnlocked = true;

    [Header("Activity Effects")]
    [SerializeField] private Effect requirements;
    [SerializeField] private Effect production;

    [Header("UI")]
    [SerializeField] private RepresentationColorData colorData;

    public string Name => activityName;
    public ActivityType Type => activityType;
    public bool InitiallyUnlocked => initiallyUnlocked;
    public Effect Requirements => requirements;
    public Effect Production => production;
    public RepresentationColorData ColorData => colorData;
}
