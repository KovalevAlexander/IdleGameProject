using UnityEngine;

[CreateAssetMenu(menuName = "Game/Activities/Resource Production")]
public class ResourceProduction : ActivityProduction
{
    [SerializeField] private ResourceDictionary production;

    public override bool CanProduce => Check();

    private bool Check()
    {
        var RM = ResourcesManager.Instance;

        foreach (var resource in production.Keys)
        {
            if (RM.GetResource(resource).Maxed)
            {
                return false;
            }
        }

        return true;
    }

    public float this[ResourceType type]
    {
        get
        {
            return production[type];
        }
    }
}
