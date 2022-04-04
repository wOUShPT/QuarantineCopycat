using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FMODEventSource), true)]
public class FMODEventSourceCustomInspector : Editor
{
    private string[] _FMODEventTypes = { "2D", "3D"};
    private int _currentTypeIndex = 0;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _currentTypeIndex = EditorGUILayout.Popup("Event Type",_currentTypeIndex, _FMODEventTypes);
        serializedObject.FindProperty("currentTypeIndex").intValue = _currentTypeIndex;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("FMODEvent"));
        if (serializedObject.FindProperty("currentTypeIndex").intValue == 1)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sourceGameObject"), new GUIContent("Event Source Gameobject"));

        }

        serializedObject.ApplyModifiedProperties();
    }


    
}
