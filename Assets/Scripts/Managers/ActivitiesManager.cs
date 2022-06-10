using System;
using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
using System.Linq;

public sealed class ActivitiesManager : Singleton<ActivitiesManager>
{
    [Header("UI")]
    [SerializeField] ActivityRootsDictionary uiRoots = new();
    [SerializeField] GameObject uiPrefab;

    private readonly Representer<Activity, ActivityRepresentation> m_Representer = new();
    private List<Activity> m_Activities = new();

    private List<Activity> m_ActiveActivities = new();
    private int m_ActiveRepeatableActivitiesLimit = 1;
    private int m_ActiveRepeatables = 0;

    private void Start()
    {
        ReferenceManager.Instance.TM.onLocationChange = RegisterActivities;
        ReferenceManager.Instance.RM.onResourcesUpdate = HandleResourceUpdate;
    }

    private void HandleResourceUpdate()
    {
        foreach (var activity in m_Activities)
            activity.Update();
    }

    private void Update()
    {
        var activities = m_ActiveActivities.ToList();
        activities.RemoveAll(activity => activity == null);

        for (int i = activities.Count-1; i >= 0; i--)
        {
            activities[i].Run();
        }
    }

    private void RegisterActivities(ActivitiesList activities)
    {
        ClearActivities();

        foreach (ActivityData data in activities.ToList())
        {
            var activity = ActivityFactory.Get(data);

                m_Activities.Add(activity);
        }

        //Replacing activities with the matching old ones.
        foreach(var activeActivity in m_ActiveActivities)
        {
            if (m_Activities.Where(activity => 
            activity.ActivityData == activeActivity.ActivityData).Count() > 0)
            {
                m_Activities.RemoveAll(activity => activity.ActivityData == activeActivity.ActivityData);
                m_Activities.Add(activeActivity);
            }

        }

        //Create representation for new activities
        m_Representer.CreateRepresentations(
            m_Activities.ToArray(), 
            uiPrefab, 
            ResolveRoots());

        //And for the persistent activties

        var representations = m_Representer.GetRepresentations();

        foreach (var representation in representations)
            representation.onClicked = HandleActivityClicked;
    }

    private void ClearActivities()
    {
        foreach (var activity in m_Activities)
            activity.Dispose();

        var nonPersistentActivities = m_ActiveActivities.Where(activity => !activity.IsAvailable).ToList();

        for (int i = nonPersistentActivities.Count - 1; i >= 0; i--)
        {
            StopActivity(nonPersistentActivities[i]);
        }

        m_Activities.Clear();
        m_Representer.Clear();
    }

    private void SavePersistentActivities()
    {
    }

    private Transform[] ResolveRoots()
    {
        var array = new Transform[m_Activities.Count];

        for (int i = 0; i < array.Length; i++)
            array[i] = uiRoots[m_Activities[i].Type];

        return array;
    }

    private void HandleActivityClicked(Activity activity)
    {
        if (IsActive(activity))
            StopActivity(activity);
        else
            ActivateActivity(activity);
    }

    public void StopActivity(Activity activity)
    {
        if (activity is RepeatableActivity)
            m_ActiveRepeatables -= 1;

        m_ActiveActivities.Remove(activity);
        activity.Update();
    }

    public void ActivateActivity(Activity activity)
    {
        if (activity is RepeatableActivity && m_ActiveRepeatables == m_ActiveRepeatableActivitiesLimit)
            StopActivity(m_ActiveActivities[0]);

        if (activity is RepeatableActivity)
            m_ActiveRepeatables += 1;

        m_ActiveActivities.Add(activity);
        activity.Update();
    }

    public bool IsActive(Activity activity)
    {
        return m_ActiveActivities.Contains(activity);
    }
}

[Serializable]
public class ActivityRootsDictionary : SerializableDictionaryBase<ActivityType, Transform>
{
}