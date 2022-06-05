using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesManager : Singleton<ActivitiesManager>
{
    private List<Activity> _Activities = new();
    private Activity _currentActivity;

    public void RegisterActivity(Activity activity)
    {
        if (_Activities.Contains(activity))
        {
            return;
        }

        activity.onPressed = HandleActivityPressed;
        _Activities.Add(activity);
    }

    public void RemoveActivity(Activity activity)
    {
        _Activities.Remove(activity);
    }
    public void AssignCurrentActivity(Activity activity)
    {
        _currentActivity = activity;
    }

    private void HandleActivityPressed(Activity activity)
    {
        if (!_Activities.Contains(activity))
        {
            return;
        }

        if (_currentActivity == activity)
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
        _currentActivity?.Run();
    }
}
