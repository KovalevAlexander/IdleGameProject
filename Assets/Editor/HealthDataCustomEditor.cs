using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HealthData))]
[CanEditMultipleObjects]
public class HealthDataCustomEditor : Editor
{

    SerializedProperty[] m_Properties = new SerializedProperty[4];

    private void OnEnable()
    {
        m_Properties[0] = serializedObject.FindProperty("type");
        m_Properties[1] = serializedObject.FindProperty("initialMaxValue");
        m_Properties[2] = serializedObject.FindProperty("initialValue");
        m_Properties[3] = serializedObject.FindProperty("colorData");

    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginDisabledGroup(true);

            EditorGUILayout.ObjectField("Custom Editor Script", MonoScript.FromScriptableObject(this), typeof(HealthDataCustomEditor), false);

            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject(serializedObject.targetObject as ScriptableObject), typeof(HealthData), false);
        
            EditorGUILayout.PropertyField(m_Properties[0]);

        EditorGUI.EndDisabledGroup();

        for (int i = 1; i < m_Properties.Length; i++)
        {
            EditorGUILayout.PropertyField(m_Properties[i]);
        }
    }
}
