using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ReferenceManager : Singleton<ReferenceManager>
{
    [SerializeField] ResourcesManager resourcesManager;
    [SerializeField] TravelMananger travelMananger;
    [SerializeField] ActivitiesManager activitiesManager;

    public ResourcesManager RM => resourcesManager;
    public TravelMananger TM => travelMananger;
    public ActivitiesManager AM => activitiesManager;
}
