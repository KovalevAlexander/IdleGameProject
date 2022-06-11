using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract bool CanApply();
    public abstract void Apply();
}
