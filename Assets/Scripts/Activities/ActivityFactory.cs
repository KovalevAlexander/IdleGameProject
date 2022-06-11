using System;
using System.Collections.Generic;

public static class ActivityFactory
{
    private static readonly Dictionary<ActivityType, Type> m_FactoryDictionary = new()
    {
        { ActivityType.Repeatable,  typeof(RepeatableActivity)  },
        { ActivityType.Action,      typeof(ActionActivity)      },
        { ActivityType.Progression, typeof(ProgressionActivity) },
        { ActivityType.Dungeon,     typeof(DungeonActivity)     }
    };

    public static Activity Get(ActivityData data) 
        => (Activity)Activator.CreateInstance(m_FactoryDictionary[data.Type], new object[] { data });
}
