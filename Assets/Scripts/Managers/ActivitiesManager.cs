using System;
using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
public sealed class ActivitiesManager : Representer<Activity>
{
    [SerializeField] ActivityRootsDictionary UIRoots = new();

    private List<Activity> m_Activities = new();
    private Activity m_CurrentActivity;

    private void OnEnable()
    {
        var TM = TravelMananger.Instance as TravelMananger;
        TM.onLocationChange = RegisterActivities;
    }

#if !UNITY_EDITOR
    private void OnDisable()
    {
        TravelMananger.Instance.onLocationChange = null;
    }
#endif

    private void RegisterActivities(ActivitiesList activities)
    {
        m_Activities.Clear();

        foreach (ActivityData activityData in activities.ToList())
        {
            var activity = ActivityFactory.Get(activityData);
            activity.onPressed = HandleActivityPressed;
            m_Activities.Add(activity);
        }

        CreateRepresentations();
    }
    protected override void CreateRepresentations()
    {
        foreach (var representable in m_Activities)
        {
            if (!m_Representations.Contains(representable.Representation))
            {
                var representation = RepresentationFactory<ActivityRepresentation>.Get(representable, UIPrefab, UIRoots[representable.Type], colorData);
                m_Representations.Add(representation);
            }

        }
    }

    public void AssignCurrentActivity(Activity activity)
    {
        m_CurrentActivity = activity;
    }

    private void HandleActivityPressed(Activity activity)
    {
        if (!m_Activities.Contains(activity))
        {
            return;
        }

        if (m_CurrentActivity == activity)
        {
            AssignCurrentActivity(null);
            activity.onStopped?.Invoke();
            return;
        }

        if (activity.CanActivate())
        {
            activity.onActive?.Invoke();
            AssignCurrentActivity(activity);
        }
    }

    private void Update()
    {
        m_CurrentActivity?.Run();
    }
}

[Serializable]
public class ActivityRootsDictionary : SerializableDictionaryBase<ActivityType, Transform>
{
}