using UnityEngine;

public sealed class ReferenceManager : Singleton<ReferenceManager>
{
    [SerializeField] ResourcesManager resourcesManager;
    [SerializeField] TravelMananger travelMananger;
    [SerializeField] ActivitiesManager activitiesManager;
    [SerializeField] GameMenuManager gameMenuManager;

    public ResourcesManager ResourcesManager => resourcesManager;
    public TravelMananger TravelManager => travelMananger;
    public ActivitiesManager ActivitiesManager => activitiesManager;
    public GameMenuManager GameMenuManager => gameMenuManager;
}
