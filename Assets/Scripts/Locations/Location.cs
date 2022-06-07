using UnityEngine;

[CreateAssetMenu(menuName = "Game/Locations/Location")]
public sealed class Location : ScriptableObject, IRepresentable
{
    [SerializeField] private string locationName;
    [SerializeField] private ActivitiesList Activities;

    private IRepresentation m_Representation;
    public string Name => locationName;

    public IRepresentation Representation { get => m_Representation; set => m_Representation = value; }

    public ActivitiesList GetActivitiesList()
    {
        return Activities;
    }
}
