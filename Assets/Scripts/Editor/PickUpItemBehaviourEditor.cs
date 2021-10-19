using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PickUpItemBehaviour))]
public class PickUpItemBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PickUpItemBehaviour pickUpItemBehaviour = (PickUpItemBehaviour)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("objectType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("waitOnPickup"));

        switch (pickUpItemBehaviour.ObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Book:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("bookParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("clothParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Any:
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
