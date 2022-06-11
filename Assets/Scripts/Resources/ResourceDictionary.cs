using System.Collections;

using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class ResourceDictionary : SerializableDictionaryBase<ResourceType, float> 
{
    public ResourceDictionary Scale(float scalefactor)
    {
        var copy = new ResourceDictionary();
        this.CopyTo(copy);

        ResourceType[] types = new ResourceType[copy.Count];
        copy.Keys.CopyTo(types, 0);
        
        for (int i = 0; i < types.Length; i++)
        {
            copy[types[i]] *= scalefactor;
        }

        return copy;
    }
}