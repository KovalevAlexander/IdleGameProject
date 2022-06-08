using System;
using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;

public sealed class ActivitiesManager : Singleton<ActivitiesManager>
{
    [Header("UI")]
    [SerializeField] ActivityRootsDictionary uiRoots = new();
    [SerializeField] GameObject uiPrefab;

    private readonly ActivitiesRepresenter m_Representer = new();
    private List<Activity> m_Activities = new();

    private Activity m_CurrentActivity;

    private void OnEnable()
    {
        TravelMananger.Instance.onLocationChange = RegisterActivities;
    }

#if !UNITY_EDITOR
    private void OnDisable()
    {
        TravelMananger.Instance.onLocationChange = null;
    }
#endif

    private void Update()
    {
        m_CurrentActivity?.Run();
    }

    private void RegisterActivities(ActivitiesList activities)
    {
        m_Activities.Clear();
        m_Representer.Clear();

        foreach (ActivityData activityData in activities.ToList())
        {
            var activity = ActivityFactory.Get(activityData);
            activity.onPressed = HandleActivityPressed;

            m_Activities.Add(activity);
        }

        m_Representer.CreateRepresentations(m_Activities.ToArray(), uiPrefab, ResolveRoots());
    }
    private Transform[] ResolveRoots()
    {
        var array = new Transform[m_Activities.Count];

        for (int i = 0; i < array.Length; i++)
            array[i] = uiRoots[m_Activities[i].Type];

        return array;
    }

    public void AssignCurrentActivity(Activity activity)
    {
        m_CurrentActivity = activity;
    }

    private void HandleActivityPressed(Activity activity)
    {
        if (!m_Activities.Contains(activity))
            return;

        if (m_CurrentActivity == activity)
        {
            StopActivity(activity);
            return;
        }

        if (activity.IsAvailable())
            ActivateActivity(activity);
    }

    public void StopActivity(Activity activity)
    {
        if (activity == m_CurrentActivity)
        {
            AssignCurrentActivity(null);
            activity.onStopped?.Invoke();
        }
    }
    
    private void ActivateActivity(Activity activity)
    {
        activity.onActivated?.Invoke();
        AssignCurrentActivity(activity);
    }
}

[Serializable]
public class ActivityRootsDictionary : SerializableDictionaryBase<ActivityType, Transform>
{
}