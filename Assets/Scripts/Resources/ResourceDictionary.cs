using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class ResourceDictionary : SerializableDictionaryBase<ResourceType, float> 
{
    public void Scale(float scalefactor)
    {
        foreach (var key in Keys)
            this[key] *= scalefactor;
    }
}