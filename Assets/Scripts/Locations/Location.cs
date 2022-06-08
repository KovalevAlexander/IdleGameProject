using UnityEngine;

[CreateAssetMenu(menuName = "Game/Locations/Location")]
public sealed class Location : ScriptableObject, IRepresentable
{
    [Header("General")]
    [SerializeField] private string locationName;
    [SerializeField] private ActivitiesList Activities;

    [Header("UI")]
    [SerializeField] private RepresentationColorData colorData;

    private IRepresentation m_Representation;
    public string Name => locationName;

    public IRepresentation Representation { get => m_Representation; set => m_Representation = value; }

    public RepresentationColorData ColorData => colorData;

    public ActivitiesList GetActivitiesList()
    {
        return Activities;
    }
}
