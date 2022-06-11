using System;
using System.Collections.Generic;

using UnityEngine;

public sealed class TravelMananger : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Location defaultLocation;
    [SerializeField] private List<Location> locations = new();

    [Header("UI")]
    [SerializeField] Transform uiRoot;
    [SerializeField] GameObject uiPrefab;

    public Action<ActivitiesList> onLocationChange;

    private readonly Representer<Location, LocationRepresentation> m_Representer = new();

    private Location m_CurrentLocation;

    private void Start()
    {
        ChangeLocation(defaultLocation);

        m_Representer.CreateRepresentations(locations.ToArray(), uiPrefab, uiRoot);

        foreach (var representation in m_Representer.GetRepresentations())
            representation.onClicked = ChangeLocation;
    }

    public void ChangeLocation(Location location)
    {
        if (m_CurrentLocation == location)
            return;

        m_CurrentLocation = location;

        onLocationChange?.Invoke(m_CurrentLocation.GetActivitiesList());
    }
}
