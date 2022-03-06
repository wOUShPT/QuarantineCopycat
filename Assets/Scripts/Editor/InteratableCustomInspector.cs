using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableBehaviour), true)]
public class InteratableCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUIStyle _titleStyle = new GUIStyle("Toolbar");;
        _titleStyle.alignment = TextAnchor.MiddleCenter;
        _titleStyle.fontSize = 12;
        _titleStyle.fixedHeight = 22;

        serializedObject.Update();
        
        base.OnInspectorGUI();
        
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        GuiLine();
        Color defaultBackgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.blue;
        EditorGUILayout.LabelField("Interactable Base Settings", _titleStyle);
        GUI.backgroundColor = defaultBackgroundColor;
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactionDistance"), new GUIContent("Interaction Max Distance"));
        EditorGUILayout.Separator();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("gameObjectsOutlinedArray"), new GUIContent("GameObjects To Outline"));
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        serializedObject.ApplyModifiedProperties();
    }
    
    void GuiLine( int i_height = 1 )
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height );

        rect.height = i_height;

        EditorGUI.DrawRect(rect, new Color ( 0.5f,0.5f,0.5f, 1 ) );

    }
}
