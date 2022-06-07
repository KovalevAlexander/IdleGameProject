using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Activity Requirments")]
public abstract class ActivityRequirements : ActivityEffect
{
    public abstract bool AreMet { get; }
}
