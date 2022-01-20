using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CinemachineFPExtension), true)]
[CanEditMultipleObjects]
public class CinemachineFPExtensionInspector : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CinemachineFPExtension cinemachineFpExtension = (CinemachineFPExtension)target;

        EditorGUILayout.LabelField("Sensitivity");
        
        EditorGUILayout.Separator();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("mouseSettingsData"), GUIContent.none);
        
        EditorGUILayout.BeginHorizontal();
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("horizontalSpeed"), GUIContent.none);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("verticalSpeed"), GUIContent.none);

        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Clamp Movement On Axis");
        
        EditorGUILayout.Separator();

        EditorGUILayout.BeginHorizontal();
        
        EditorGUILayout.LabelField("X Axis", GUILayout.Width(50));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isClampedOnXAxis"), GUIContent.none);

        if (cinemachineFpExtension.isClampedOnXAxis)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("clampXViewAngle"), GUIContent.none);
        }
        
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        
        EditorGUILayout.LabelField("Y Axis", GUILayout.Width(50));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isClampedOnYAxis"),
            GUIContent.none);

        if (cinemachineFpExtension.isClampedOnYAxis)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("clampYViewAngle"), GUIContent.none);
        }
        
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.Space(20);
        
        GuiLine();

        EditorGUILayout.Separator();
        
        EditorGUI.BeginDisabledGroup(true);
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_currentRotation"));
        
        EditorGUI.EndDisabledGroup();

        serializedObject.ApplyModifiedProperties();
    }
    
    void GuiLine( int i_height = 1 )
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height );

        rect.height = i_height;

        EditorGUI.DrawRect(rect, new Color ( 0.5f,0.5f,0.5f, 1 ) );

    }
}
