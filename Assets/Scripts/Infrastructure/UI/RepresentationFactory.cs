using System;
using System.Collections.Generic;
using UnityEngine;

public static class RepresentationFactory<T> where T : IRepresentation
{
    private static readonly Dictionary<Type, Func<IRepresentable, GameObject, RepresentationColorData, IRepresentation>> m_FactoryDictionary = new()
    {
        { typeof(Resource), ResourceRepresentation },
        { typeof(Location), LocationRepresentation },
        { typeof(Activity), ActivityRepresentation }
    };

    public static T Get(IRepresentable representable, GameObject uiPrefab, Transform root, RepresentationColorData colorData)
    {
        var UIGameObject = GameObject.Instantiate<GameObject>(uiPrefab, root);
        UIGameObject.name = representable.Name;

        var key = representable.GetType();
        IRepresentation representation;
        if (m_FactoryDictionary.ContainsKey(key))
        {
            representation = m_FactoryDictionary[key](representable, UIGameObject, colorData);
        }
        else representation = m_FactoryDictionary[key.BaseType](representable, UIGameObject, colorData); ;

        representable.Representation = representation;
        return (T)representation;
    }

    private static IRepresentation ResourceRepresentation(IRepresentable representable, GameObject UIGameObject, RepresentationColorData colorData)
    {
        return new ResourceRepresentation(representable as Resource, UIGameObject, colorData);
    }

    private static IRepresentation LocationRepresentation(IRepresentable representable, GameObject UIGameObject, RepresentationColorData colorData)
    {
        return new LocationRepresentation(representable as Location, UIGameObject, colorData);
    }

    private static IRepresentation ActivityRepresentation(IRepresentable representable, GameObject UIGameObject, RepresentationColorData colorData)
    {
        return new ActivityRepresentation(representable as Activity, UIGameObject, colorData);
    }

}
