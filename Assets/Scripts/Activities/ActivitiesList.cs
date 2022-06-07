using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Activities List")]
public class ActivitiesList : ScriptableObject
{
    [SerializeField] List<ActivityData> Activities = new();

    public List<ActivityData> ToList()
    {
        return Activities;
    }
}
