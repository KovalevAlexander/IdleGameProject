using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesUnlockManager : MonoBehaviour
{
    private List<Activity> m_LockedActivities = new();

    public bool IsUnlocked(Activity activity) 
        => !m_LockedActivities.Contains(activity);

    public void LockActivity(Activity activity) 
        => m_LockedActivities.Add(activity);

    public void UnlockActivity(Activity activity)
        => m_LockedActivities.Remove(activity);
}
