using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Activity Production")]
public abstract class ActivityProduction : ActivityEffect
{
    public abstract bool CanProduce { get; }
}
