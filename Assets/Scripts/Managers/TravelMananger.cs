using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class TravelMananger : Representer<Location>
{
    [Header("General")]
    [SerializeField] private Location defaultLocation;
    [SerializeField] private List<Location> locations = new();

    
    public Action<ActivitiesList> onLocationChange;

    private Location m_CurrentLocation;

    private void Start()
    {
        ChangeLocation(defaultLocation);
        CreateRepresentations();
    }

    public void ChangeLocation(Location location)
    {
        if (m_CurrentLocation == location)
            return;

        m_CurrentLocation = location;

        onLocationChange?.Invoke(m_CurrentLocation.GetActivitiesList());
    }

    protected override void CreateRepresentations()
    {
        var representables = locations;

        foreach (var representable in representables)
        {
            var representation = RepresentationFactory<LocationRepresentation>.Get(representable, UIPrefab, UIRoot, colorData);
            representation.onClicked = ChangeLocation;

            m_Representations.Add(representation);
        }
    }
}
