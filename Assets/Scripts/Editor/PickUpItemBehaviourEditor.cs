using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PickUpItemBehaviour))]
[CanEditMultipleObjects]
public class PickUpItemBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PickUpItemBehaviour pickUpItemBehaviour = (PickUpItemBehaviour)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactionDistance"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("objectType"));

        switch (pickUpItemBehaviour.ObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Book:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("bookParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("clothParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Disk:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("diskParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Bread:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("breadParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Any:
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
