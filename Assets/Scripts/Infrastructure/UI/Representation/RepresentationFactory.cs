using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public static class RepresentationFactory<T> where T : IRepresentation
{
    private static readonly Dictionary<Type, Type> m_FactoryDictionary = new()
    {
        { typeof(Resource), typeof(ResourceRepresentation) },
        { typeof(Location), typeof(LocationRepresentation) },
        { typeof(Activity), typeof(ActivityRepresentation) }
    };

    public static T Get(IRepresentable representable, GameObject uiPrefab, Transform root)
    {
        var uiGameObject = GameObject.Instantiate<GameObject>(uiPrefab, root);
        uiGameObject.name = representable.Name;

        var key = representable.GetType();
        var param = new object[] { representable, uiGameObject, "" };

        if (m_FactoryDictionary.ContainsKey(key))
        {
            return (T)Activator.CreateInstance(m_FactoryDictionary[key], param);
        }
        else return (T)Activator.CreateInstance(m_FactoryDictionary[key.BaseType], param);
    }
}
