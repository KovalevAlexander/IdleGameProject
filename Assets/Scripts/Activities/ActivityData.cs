using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Activity Data")]
public class ActivityData : ScriptableObject
{
    [Header("General")]
    [SerializeField] private string activityName;
    [SerializeField] private ActivityType activityType;
    [Header("Activity Effects")]
    [SerializeField] private ActivityRequirements requirements;
    [SerializeField] private ActivityProduction production;

    public string Name => activityName;
    public ActivityType Type => activityType;
    public ActivityRequirements Requirements => requirements;
    public ActivityProduction Production => production;
}
