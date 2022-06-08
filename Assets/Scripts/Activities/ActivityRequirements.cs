using UnityEngine;

public abstract class ActivityRequirements : ActivityEffect
{
    public abstract bool AreMet { get; }
}
